using System.Net;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;

namespace PracticeCosmos
{

class Program
    {
    static async Task Main(string[] args)
        {   
            // Note, the object names in the code can be whatever you want, but using the ones suggested
            //  will make it somewhat easier to follow in the video walkthrough and lab guide.
            //  However, use the *exact* names given for the database and container resources you will
            //  create in order to a) Help the lab grading engine properly indicate lab completion, and 
            //  b) Help k eep your .NET work separate from your Python work, should you decide to do both.
            
            //Copy the primary connection string from the Cosmos DB account in the portal and paste it in place of the placeholder, below
            string my_connection_string = "[ConnectionString]";

            //Declare a CosmosClient, called myClient, using the connection string
            
            CosmosClient myClient = new (my_connection_string);


            //Declare a Database, called myDatabase, from the Cosmos DB account called *exactly* "LabDBNet";
            
            Database myDatabase = myClient.GetDatabase("LabDBNet");

            //Declare a ContainerProperties object, called containerProps, with the minimum properties:
            //  "LabItemsNet" *exactly* for the container name and "/labPK" for the partition key path.
            //  NOTE: There is a way to create a container directly without the use of the ContainerProperties
            //  class. However, using ContainerProperties as a habit makes it easier to define additional
            //  container properties when you create a new container.
            
            //***You get this line of code as a "freebie"***
            ContainerProperties containerProps = new ContainerProperties("LabItemsNet","/labPK");


            //Declare a Container, called myContainer, on myDatabase, 
            //  passing containerProps as a single parameter.
            
            Container myContainer = myDatabase.GetContainer(containerProps);
            
            //Use the GenericItem class (just outside of the Main method) to create an item object, 
            //  called myItem, to be upserted to the container.
            //IMPORTANT: the id property should be assigned a GUID. Assign this value to that property:
            //    "70b63682-b93a-4c77-aad2-65501347265f". If you create an item with that same GUID, the
            //    upsert will overwrite the previous item. Alter the GUID value slightly if you decide
            //    to upsert more than one item. The labPK property can be assigned any int and the name
            //    property can be any string.

            GenericItem myItem = new(
              id: "70b63682-b93a-4c77-aad2-65501347265f",
              itemName: "This is my string",
              labPK: 5
            );
                       
            //Upsert your item to the container you created
            // Hint: The Main method is an async Task, so instantiate and ItemReponse object to "kick off"
            // the task. Your code will start like this:
            //                            ItemResponse response = await . . . 
            
            ItemResponse item = await this.container.CreateItemAsync(test, new PartitionKey(test.status));

    }
        
        public class GenericItem
        {
            public Guid id {get; set;}
            public string? itemName {get; set;}
            public int labPK {get; set;} 
        }   
    
  }
}       
