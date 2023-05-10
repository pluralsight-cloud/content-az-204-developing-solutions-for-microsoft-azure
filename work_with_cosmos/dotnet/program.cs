using System.Net;
using Microsoft.Azure.Cosmos;

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
            //  b) Help keep your .NET work separate from your Python work, should you decide to do both.
            
            //Copy the primary connection string from the Cosmos DB account in the portal and paste it in place of the placeholder, below
            string my_connection_string = "[PASTE CONNECTION STRING, WRAPPED IN DOUBLE-QUOTES, HERE]";

            //Declare a CosmosClient, called myClient, using the connection string
            
            CosmosClient myClient = new (my_connection_string);


            //Asynchronously create a Database, called myDatabase, with a resource Id/name of *exactly* "LabDBNet";
            //Requirement: Attempt to create the database only if it does not already exist.
            //Hints: The code for this code and most of the other commands that follow will be in this form:
            //      Class myClass = await myPreviousObject.Create{Class}IfNotExistsAsync({one or more properties});
            
            Database myDatabase = await myClient.CreateDatabaseIfNotExistsAsync("LabDBNet");

            //Asynchronously create a Container, called myContainer, on myDatabase, if it does not already exist,
            //  passing in the *exact* name of "LabItemsNet" and a partition key of *exactly* "/labPK"
            
            Container myContainer = await myDatabase.CreateContainerIfNotExistsAsync("LabItemsNet","/labPK");
            
            //Use the GenericItem record (just outside of the Main method) to create an item object, 
            //  called myItem, to be upserted to the container.
            //IMPORTANT: the id property should be assigned a unique value, such as a GUID, like this:
            //    "70b63682-b93a-4c77-aad2-65501347265f". The itemName property can be assigned any string and 
            //    the labPK property, which is the partition key, should be assigned an appropriate
            //    partition key value — perhaps, a city name, such as "Springfield" or "New Delhi" — 
            //    though, there are no actual constraints preventing labPK from being any value you choose.

            GenericItem myItem = new(
              id: "70b63682-b93a-4c77-aad2-65501347265f",
              itemName: "This is my string",
              labPK: "active"
            );
                       
           // Declare a GenericItem to asynchronously upsert myItem to myContainer.
           GenericItem upsertedItem = await myContainer.UpsertItemAsync<GenericItem>(myItem, new PartitionKey(myItem.labPK));

    } 
    public record GenericItem (
    string id,
    string itemName,
    string labPK 
    );   
  }
}       
