# coding: utf-8

"""
FILE: samplecode.py
DESCRIPTION:
    This file provides a guided experience in performing a few basic tasks against Azure Cosmos DB.
USAGE: python samplecode.py
    IMPORTANT:
    Make sure you have retrieved the primary connection string from the pre-deployed Cosmos DB account
    using the Azure Portal. Find the my_connection_string variable, below, and assign the connection string
    that you copied to that variable by pasting it between the double-quotes.
    
    Save your work before running the code.
"""
import os

class PythonCosmosLab(object):

    # Hint: To make use of this variable in code, you need to prepend them with "self" like this: self.my_connection_string and self.source_file
    my_connection_string = "[PASTE CONNECTION STRING, WRAPPED IN DOUBLE-QUOTES, HERE]"

    def practice_operations(self):

        # Instantiate a CosmosClient using a connection string
        """
        Hint: This requires two lines of code:
        First, you will need to import the CosmosClient and PartitionKey from azure.cosmos,
        then, you will instantiate the CosmosClient object.
        """

        # [Put your code here]        
        from azure.cosmos import CosmosClient, PartitionKey
        my_cosmos_client = CosmosClient.from_connection_string(self.my_connection_string)

        # Instantiate a Database object and create the database if it does not already exist.
        """
        Instructions:
        Name the Database object anything you like, but use this *exact* name for the database
        that you want to add Cosmos account: "LabDBPython".
        (This allows the lab grading feature to correctly detect that you completed the objective.)

        Hint:
        There are a few ways to do this, but in the solution video and the lab guide, 
        we will be creating the container using the CosmosClient object we just instantiated.
        It's just one line of code to instantiate the object and create the database.
        """
        # [Put your code here]
        my_database = my_cosmos_client.create_database_if_not_exists("LabDBPython")
        
        # Instantiate a Container object and create the container on the database you just created.
        """
        Instructions:
        Name the Container object anything you like, but use this *exact* name for the container
        that you want to add to the LabDBPython database: "LabItemsPython".
        (This allows the lab grading feature to correctly detect that you completed the objective.)

        Hints:
        --There are a few ways to do this, but in the solution video and the lab guide, 
          we will be creating the container using the Database object we just instantiated.
          
        --It's just one line of code to instantiate the object and create the container.
        
        --The code should pass the name of the container and the partition key path and just let
           the throughput value default. You have been provided with a variable for the
           partition key path that you need to use in your code.
        """
        partition_key_path = PartitionKey(path="/labPK")
        # [Put your code here]
        my_container = my_database.create_container_if_not_exists ("LabItemsPython",partition_key_path)
        

        # Insert an item into the container
        """
        Hints:
        --There are a few ways to do this, but in the solution video and the lab guide, 
        we will be creating the item using the Container object we just instantiated.

        --A generic item has been created for you.

        """ 
        generic_item = {'id' : '70b63682-b93a-4c77-aad2-65501347265f',
                       'itemName': 'AnyStringWillDo',
                       'labPK': 'New Delhi'
                       }

        # [Put your code here]
        my_container.create_item(body=generic_item)

    
      
example=PythonCosmosLab()
example.practice_operations()
