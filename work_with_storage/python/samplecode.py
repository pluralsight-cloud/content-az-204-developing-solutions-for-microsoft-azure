# coding: utf-8

"""
FILE: samplecode.py
DESCRIPTION:
    This file provides a guided experience in performing a few basic tasks against Azure Blob storage.
USAGE: python samplecode.py
    IMPORTANT:
    Make sure you have retrieved the primary connection string from the pre-deployed storage account
    using the Azure Portal. Find the my_connection_string variable, below, and assign the connection string
    that you copied to that variable by pasting it between the double-quotes.

    Take note of the source_file variable just below the my_connection_string variable. You will need that
    for the last block of code in this exercise.
    
    Save your work before running the code.
"""
import os

class PythonBlobLab(object):

    # Hint: To make use of these variables in code, you need to prepend them with "self" like this: self.my_connection_string and self.source_file
    my_connection_string = "[PASTE YOUR CONNECTION STRING WRAPPED IN DOUBLE-QUOTES]"
    source_file = "BlobSample.txt"

    def practice_operations(self):

        # Instantiate a BlobServiceClient using a connection string
        """
        Hint: This requires two lines of code:
        First, you will need to import the BlobServiceClient from azure.storage.blob,
        then, you will instantiate the client object.
        """

        # [Put your code here]        
        from azure.storage.blob import BlobServiceClient
        my_blob_service_client = BlobServiceClient.from_connection_string(self.my_connection_string)

        # Instantiate a ContainerClient object and create the container.
        """
        Instructions:
        Name the ContainerClient object anything you like, but use this *exact* name for the container
        that you want to add to the storage account: "containerforlab".
        (This allows the lab grading feature to correctly detect that you completed the objective.)

        Hint:
        There are a few ways to do this, but in the solution video and the lab guide, 
        we will be creating the container using the BlobServiceClient object we just instantiated.
        It's just one line of code to instantiate the object and create the container.
        """
        # [Put your code here]
        my_container_client = my_blob_service_client.create_container("containerforlab")

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
            file that we assigned to the self.source_file variable near the top of this file,
            and then follow that with the upload_blob method on the BlobCient we just created.
        --The open function takes two arguments, the first is the path to the source file, this case, self.source_file,
            and the second is the mode. The mode we want to use in this case is "rb", which stands for "read binary".   

        """
        
        # [Put your code here]
        with open(self.source_file, "rb") as data:
            my_blob_client.upload_blob(data, blob_type="BlockBlob")

       

example=PythonBlobLab()
example.practice_operations()

