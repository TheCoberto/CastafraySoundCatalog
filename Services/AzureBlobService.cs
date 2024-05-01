using Azure.Storage;
using Azure.Storage.Blobs;
using System;
using System.Web;
using static CastafraySoundCatalog.Globals;

namespace CastafraySoundCatalog.Services
{
    public class AzureBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public AzureBlobService()
        {
            var credential = new StorageSharedKeyCredential(AzureStorageAccountName, AzureStorageAccountKey);
            var bloburi = $"https://{AzureStorageAccountName}.blob.core.windows.net";
            _blobServiceClient = new BlobServiceClient(new Uri(bloburi), credential);
        }

        public string UploadFile(HttpPostedFileBase file)
        {
            var blobName = file.FileName;
            var stream = file.InputStream;
            var blobContainer = _blobServiceClient.GetBlobContainerClient("all");
            var blob = blobContainer.GetBlobClient(blobName);

            blob.Upload(stream, true);

            string blobUrl = blob.Uri.AbsoluteUri;
            return blobUrl;
        }
    }
}