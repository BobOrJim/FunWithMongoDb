using Infrastructure;
using MongoDB.Bson;
using Shared.Interfaces;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class ConsoleMenu
    {
        private readonly IDataAccess _dataAccess;

        public ConsoleMenu(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        //CRUD på databases 1-4
        //CRUD på collections 5-8
        //CRUD på MyRandomData 9-12

        public void Run()
        {
            Console.Clear();
            while (true)
            {
                switch (ConsoleUtilities.AskCLIForInt("1=CreateDb 2=ReadAllDbs 4=DeleteDatabase 5=CreateCollection 6=ReadAllCollections 8=DeleteCollection 9=CreateDocument 10=ReadAllDocuments 11=UpsertRecord 12=DeleteRecord 99=Exit"))
                {
                    //CRUD om mongo Db
                    case 1:
                        Console.Clear();
                        _dataAccess.CreateDb(ConsoleUtilities.AskCLIForString("Enter db name"));
                        break;
                    case 2:
                        foreach (var dbName in _dataAccess.ReadAllDbs())
                        {
                            Console.WriteLine(dbName);
                        }
                        break;
                    case 3: 
                        _dataAccess.UpdateDatabase(); //Redundant
                        break;
                    case 4:
                        Console.Clear();
                        _dataAccess.DeleteDatabase(ConsoleUtilities.AskCLIForString("Enter db name"));
                        break;


                    //CRUD on mongo collections
                    case 5:
                        _dataAccess.CreateCollection(ConsoleUtilities.AskCLIForString("Enter database"), ConsoleUtilities.AskCLIForString("Enter collection"));
                        break;
                    case 6:
                        foreach (var collectionName in _dataAccess.ReadAllCollections(ConsoleUtilities.AskCLIForString("Enter database")))
                        {
                            Console.WriteLine(collectionName);
                        }
                        break;
                    case 7:
                        _dataAccess.UpdateCollection(); //Redundant
                        break;
                    case 8:
                        _dataAccess.DeleteCollection(ConsoleUtilities.AskCLIForString("Enter database"), ConsoleUtilities.AskCLIForString("Enter collection"));
                        break;


                    //CRUD on mongo documents
                    case 9:
                        string database = ConsoleUtilities.AskCLIForString("Enter database");
                        string collection = ConsoleUtilities.AskCLIForString("Enter collection");
                        AddressModel addressModel = new AddressModel { Id=Guid.NewGuid(), City = "borås", State = "VG", StreetAddress = "Knutbyvägen", ZipCode = "555 55" };
                        _dataAccess.CreateDocument(database, collection, addressModel);
                        break;
                    case 10:
                        foreach (var document in _dataAccess.ReadAllDocuments<BsonDocument>(ConsoleUtilities.AskCLIForString("Enter database"), ConsoleUtilities.AskCLIForString("Enter collection")))
                        {
                            Console.WriteLine(document);
                        }
                        break;
                    case 11:
                        Guid guid = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709");
                        addressModel = new AddressModel { Id = guid, City = "Ulricehamn", State = "VG", StreetAddress = "Knutbyvägen", ZipCode = "555 55" };
                        _dataAccess.UpsertRecord(ConsoleUtilities.AskCLIForString("Enter database"), ConsoleUtilities.AskCLIForString("Enter collection"), guid, addressModel);
                        break;
                    case 12:
                        guid = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709");
                        _dataAccess.DeleteRecord<AddressModel>(ConsoleUtilities.AskCLIForString("Enter database"), ConsoleUtilities.AskCLIForString("Enter collection"), guid);
                        break;


                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }
        }
    }
}
