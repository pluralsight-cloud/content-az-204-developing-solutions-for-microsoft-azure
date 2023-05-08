# coding: utf-8

"""
FILE: samplecode.py
DESCRIPTION:
    This file provides a guided experience in performing a few basic tasks against Azure Blob storage.
USAGE: python samplecode.py
    IMPORTANT:
    Before working with this sample, you should have already set up two environment variables
    at the command line:
    AZURE_STORAGE_CONNECTION_STRING = "<connection string you retrieved in the portal>"
    and 
    SOURCE_FILE = 'BlobSample.txt'
    Refer back to the lab instructions if you have not yet done this.
"""
import os
from azure.core.exceptions import ResourceNotFoundError, ResourceExistsError

class PythonBlobLab(object):

    my_connection_string = os.getenv("AZURE_STORAGE_CONNECTION_STRING")
    my_blob = os.getenv(

    def practice_operations(self):

        # Instantiate a BlobServiceClient using a connection string
      """
      Hint: This requires two lines of code:
      First, you will need to import the BlobServiceClient from azure.storage.blob,
      then, you will instantiate the client object.
      """
        from azure.storage.blob import BlobServiceClient
        my_blob_service_client = BlobServiceClient.from_connection_string(self.my_connection_string)

        # Create a new container on the storage account.
      """
      Instructions:
      Name the ContainerClient object anything you like, but use this *exact* name for the container
      that you want to add to the storage account: "containerforlab".

      Hint:
      There are a few ways to do this, but in the solution video and the lab guide, 
      we will be creating the container using the BlobServiceClient object we just instantiated.
      It's just one line of code.
      """
        try:
          # [Put your code here]
            my_container_client = my_blob_service_client.create_container("containerforlab")
        except ResourceExistsError:
                print("Container already exists.")

      
        # Instantiate a new BlobClient object
      """
      Hints:
      --There are a few ways to do this, but in the solution video and the lab guide, 
      we will be creating the object using the ContainerClient object we just instantiated.

      --It's just one line of code that uses the get_blob_client method on the ContainerClient.

      --You will pass the blob name as a string in the method, even though the blob does not yet exist.
      """ 
      
          # [Put your code here]
            my_blob_client = my_container_client.get_blob_client("blobforlab")

      
        #Upload the SOURCE_FILE using the blob client
      """
      Instructions:
      The blob type is "BlockBlob"
      
      Hints:
      --There are a few ways to do this, but in the solution video and the lab guide, 
              we will be using the "with open() as data:" construct to open the locally stored
              file that we assigned to the SOURCE_FILE environment variable previously,
              and then use the upload_blob method on the BlobCient we just created.

      """
            # [Put your code here]
            with open(SOURCE_FILE, "myfile") as data:
                my_blob_client.upload_blob(data, blob_type="BlockBlob")
