xUnit-MongoDB-DataAttribute
===========================

xUnit Data Attribute to read test data from a MongoDB instance

On test method:
1) Apply xUnit Extension Theory Attribute
      [Theory]
2) Add MongoDBData Attribute passing in the name of the desired collection containing the test data
        [MongoDBData("MyCollection")]
        
3) Create a method with the first parameter of GenericTestEntity
        public void TestMongoDBAttribute(GenericTestEntity props)
        
        
NOTE:
C# Does not support the creation of generic attributes!
     [MongoDBData<MyClass>("MyCollection")] // ERROR
     
MongoDB is a NoSql database. There are no tables, rows, columns, etc.



Enjoy writing Unit Tests with MongoDB! =D
