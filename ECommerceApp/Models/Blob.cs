using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{

    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }

        public CloudBlobClient CloudBlobClient { get; set; }


        public Blob(IConfiguration configuration)
        {
            var storageCreds = new StorageCredentials(configuration["Storage-Account-Name"], configuration["BlobKey"]);

            CloudStorageAccount = new CloudStorageAccount(storageCreds, true);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();

        }

        /// <summary>
        /// Gets the container from Azure Blob
        /// </summary>
        /// <param name="containerName">name of container we want</param>
        /// <returns>the full container from a blob</returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();

            await cbc.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Container
            });

            return cbc;
        }

        /// <summary>
        /// method to get images from container
        /// </summary>
        /// <param name="imageName">name of the image</param>
        /// <param name="containerName">name of the container it resides in</param>
        /// <returns>image</returns>
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            var container = await GetContainer(containerName);
            CloudBlob blob = container.GetBlobReference(imageName);
        
            return blob;
        }

        /// <summary>
        /// method to upload file to a specific container
        /// </summary>
        /// <param name="containerName">name of container to put file into</param>
        /// <param name="fileName">name of file</param>
        /// <param name="filePath">path of file</param>
        /// <returns>nothing</returns>
        public async Task UploadFile(string containerName, string fileName, string filePath)
        {
            var container = await GetContainer(containerName);
            var blobFile = container.GetBlockBlobReference(fileName);
            await blobFile.UploadFromFileAsync(filePath);

        }

        /// <summary>
        /// method to delete file from a container
        /// </summary>
        /// <param name="containerName">name of container that holds the file</param>
        /// <param name="fileName">name of file to be deleted</param>
        /// <returns>nothing</returns>
        public async Task DeleteBlob(string containerName, string fileName)
        {
            var container = await GetContainer(containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.DeleteAsync();
        }
    }
}
