using Domain;
using Domain.ApplicationService;
using Domain.DTO;
using Domain.DTO.Customer;
using Domain.DTO.Produto;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BackEnd.Controllers
{
    [RoutePrefix("produto")]
    public class ProdutoController : ApiController
    {
        ProdutoUnitOfWork uow;
        ProdutoApplicationService app;
        IList<OrdenacaoStatus> status;
        string _imageRootPath = ConfigurationManager.AppSettings["ImageRootPath"];
        string _containerName = ConfigurationManager.AppSettings["ImagesContainer"];
        string _blobStorageConnectionString = ConfigurationManager.ConnectionStrings["BlobStorageConnectionString"].ConnectionString;

        public ProdutoController()
        {
            uow = new ProdutoUnitOfWork();
            app = new ProdutoApplicationService();
        }

        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            using (uow)
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                string root = HttpContext.Current.Server.MapPath("~/App_Data");
                var provider = new MultipartFormDataStreamProvider(root);
                UploadedImage upload = new UploadedImage();
                ProdutoDTO dto = new ProdutoDTO();

                try
                {
                    await Request.Content.ReadAsMultipartAsync(provider);

                    // Show all the key-value pairs.
                    foreach (var key in provider.FormData.AllKeys)
                    {

                        if (key != "file")
                        {
                            foreach (var val in provider.FormData.GetValues(key))
                            {
                                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ProdutoDTO));
                                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(val));
                                dto = (ProdutoDTO)serializer.ReadObject(ms);
                            }
                        }
                    }

                    // This illustrates how to get the file names.
                    foreach (MultipartFileData file in provider.FileData)
                    {
                        var arrayBytes = File.ReadAllBytes(file.LocalFileName);
                        var fileName = file.Headers.ContentDisposition.FileName.Replace("\"", "");
                        upload = new UploadedImage
                        {
                            ContentType = file.Headers.ContentDisposition.Name,
                            Data = arrayBytes,
                            Name = fileName,
                            Url = _imageRootPath + "/" + _containerName + "/" + fileName
                        };
                    }


                    //  get the container reference
                    var container = GetImagesBlobContainer();
                    // using the container reference, get a block blob reference and set its type
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(upload.Name);
                    blockBlob.Properties.ContentType = upload.ContentType;
                    // finally, upload the image into blob storage using the block blob reference
                    var fileBytes = upload.Data;
                    await blockBlob.UploadFromByteArrayAsync(fileBytes, 0, fileBytes.Length);

                    dto.Imagem = upload.Url;

                    var db = app.Post(dto);
                    uow.ProdutoRepository.Insert(db);
                    uow.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);

                }
                catch (System.Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                }

            }
        }
        private CloudBlobContainer GetImagesBlobContainer()
        {
            // use the connection string to get the storage account
            var storageAccount = CloudStorageAccount.Parse(_blobStorageConnectionString);
            // using the storage account, create the blob client
            var blobClient = storageAccount.CreateCloudBlobClient();
            // finally, using the blob client, get a reference to our container
            var container = blobClient.GetContainerReference(_containerName);
            // if we had not created the container in the portal, this would automatically create it for us at run time
            container.CreateIfNotExists();
            // by default, blobs are private and would require your access key to download.
            //   You can allow public access to the blobs by making the container public.   
            container.SetPermissions(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            return container;
        }



        [Route("pedido")]
        [HttpPost]
        public IHttpActionResult Post(List<PedidoDTO> listDTO)
        {
            using (uow)
            {
                try
                {
                    var list = app.PostPedido(listDTO);
                    foreach (var item in list)
                    {
                        uow.PedidoRepository.Insert(item);
                        uow.SaveChanges();
                    }
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("{id:int}")]
        [HttpPut]
        public async Task<HttpResponseMessage> Put(int id)
        {
            using (uow)
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                string root = HttpContext.Current.Server.MapPath("~/App_Data");
                var provider = new MultipartFormDataStreamProvider(root);
                UploadedImage upload = new UploadedImage();
                ProdutoDTO dto = new ProdutoDTO();

                try
                {
                    await Request.Content.ReadAsMultipartAsync(provider);

                    // Show all the key-value pairs.
                    foreach (var key in provider.FormData.AllKeys)
                    {
                        if (key != "file")
                        {
                            foreach (var val in provider.FormData.GetValues(key))
                            {
                                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ProdutoDTO));
                                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(val));
                                dto = (ProdutoDTO)serializer.ReadObject(ms);
                            }
                        }
                    }

                    // This illustrates how to get the file names.
                    foreach (MultipartFileData file in provider.FileData)
                    {
                        var arrayBytes = File.ReadAllBytes(file.LocalFileName);
                        var fileName = file.Headers.ContentDisposition.FileName.Replace("\"", "");
                        upload = new UploadedImage
                        {
                            ContentType = file.Headers.ContentDisposition.Name,
                            Data = arrayBytes,
                            Name = fileName,
                            Url = _imageRootPath + "/" + _containerName + "/" + fileName
                        };
                    }

                    if (upload.Data != null)
                    {
                        //  get the container reference
                        var container = GetImagesBlobContainer();
                        // using the container reference, get a block blob reference and set its type
                        CloudBlockBlob blockBlob = container.GetBlockBlobReference(upload.Name);
                        blockBlob.Properties.ContentType = upload.ContentType;
                        // finally, upload the image into blob storage using the block blob reference
                        var fileBytes = upload.Data;
                        await blockBlob.UploadFromByteArrayAsync(fileBytes, 0, fileBytes.Length);
                    }
                    dto.Imagem = upload.Url;
                    var db = uow.ProdutoRepository.GetById(id);
                    app.Put(db, dto);
                    uow.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);

                }
                catch (System.Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                }

            }
        }

        [Route("getbydescricao/{descricao}")]
        [HttpGet]
        public IHttpActionResult GetByDescricao(string descricao)
        {
            using (uow)
            {
                try
                {
                    var produtos = uow.ProdutoRepository.GetByDescricao(descricao);
                    var dto = app.ConvertDbToDto(produtos);
                    return Ok(dto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            using (uow)
            {
                try
                {
                    var produtos = uow.ProdutoRepository.GetAll();
                    var dto = app.ConvertDbToDto(produtos);
                    return Ok(dto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            using (uow)
            {
                try
                {
                    var produto = uow.ProdutoRepository.GetById(id);
                    var dto = app.ConvertDbToDto(produto);
                    return Ok(dto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("getallpedido")]
        [HttpGet]
        public IHttpActionResult GetAllPedido()
        {
            using (uow)
            {
                try
                {
                    var pedido = uow.PedidoRepository.GetAll();
                    var dto = app.ConvertDbToDtoPedido(pedido);
                    return Ok(dto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("deletepedido/{id:int}")]
        [HttpGet]
        public IHttpActionResult deletePedido(int id)
        {
            using (uow)
            {
                try
                {
                    var pedido = uow.PedidoRepository.GetById(id);
                    app.Delete(pedido);
                    uow.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("cancelarpedido/{id:int}")]
        [HttpGet]
        public IHttpActionResult cancelarPedido(int id)
        {
            using (uow)
            {
                try
                {
                    var pedido = uow.PedidoRepository.GetById(id);
                    uow.PedidoRepository.Delete(pedido);
                    uow.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (uow)
            {
                try
                {
                    var produto = uow.ProdutoRepository.GetById(id);
                    uow.ProdutoRepository.Delete(produto);
                    uow.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}