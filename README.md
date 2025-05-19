# LOrd Card Shop
LOrd Card Shop is an online platform dedicated to simplifying the buying and selling of collectible cards. The website offers features for users to purchase, sell, or simply explore information about their favorite cards. With an intuitive interface and efficient management system, LOrd Card Shop is the perfect solution for card collectors and enthusiasts.

## Table of Contents
1. <a href="#prerequisite">Prerequisite</a>
2. <a href="#projectStructure">Project Structure</a>

## Prerequisite
- ### <a href="https://visualstudio.microsoft.com/vs/">Visual Studio 2022</a>
- ### <a href="https://help.sap.com/docs/SAP_CRYSTAL_REPORTS,_DEVELOPER_VERSION_FOR_MICROSOFT_VISUAL_STUDIO">Visual Studio 2022 - SAP Crystal Reports</a>
- ### Web Browser (Chrome, Firefox, etc.)
<br />

## <section id="projectStructure">Project Structure
- ### View
  View layer is responsible for showing information to the user and interpreting the user's commands. This layer is the home for all user interfaces in the project.
- ### Controller
  This layer is responsible to validate all input from the view layer. It also responsible for delegating requests from the user to the lower layer for further processing.
- ### Handler
  This layer is responsible to handle all business logic required in the application. It will delegate the task to query from the database, including select, insert, update and delete, to the repository layer.     Please notes that there can be a single handler that accesses multiple repositories.  
- ### Repository
  Repository layer is responsible for giving access to the database and model layer via its public interfaces to acquiring references to preexisting domain objects. It provides methods to manipulate the object which will encapsulate the actual manipulation operation of data in the database. Repository also provides methods that select objects based on some criteria and return fully instantiated objects or collection of objects whose attribute meets those criteria.
- ### Factory
  You need to encapsulate all complex object creation in this layer. For example, when the client needs to create an aggregate object (an object that holds a reference to another object), the object factory must provide an interface for creating these objects. It is important to note that an object returned by the factory must in a consistent state.
- ### Model
  The model layer is responsible for representing concepts in the business or information about the business situation. The model layer is handled using entity framework tool. This folder also contains CombineModel.cs, which is the combination of TransactionHeader, TransactionDetail, TotalQuantity (by summing quantity from TransactionDetail), and TotalPrice (by summing quantity * cardPrice).
- ### Database
  The Database layer is responsible for storing and managing data. It uses SQL for the query and the data is stored in tables.
- ### Modules
  This foler contains Json.cs, which is responsible for making encoding and decoding function (later used by the web service), and Response.cs, which has 3 properties (boolean Success, string Message, and T Payload).
- ### WebServices
  Web services folder is responsible for encoding and decoding objects passed from the controller, using Json.cs in the modules folder. Web service is used as a intermediary from controller to handler. Each web service file is based on each handler file. Therefore, web service folder and handler folder should contain the same amount of files.
- ### Datasets
  This folder is responsible for creating dataset from the database. This dataset is later used by reportings to make transaction report.
- ### Reportings
  This folder is responsible for making transaction report based on the dataset file (DataSet.xsd). The report contains TransactionHeader and TransactionDetail dataset, along with sub total and grand total of each transaction.</section>
## 
