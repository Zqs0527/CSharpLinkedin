C# code file compiles to MSIL (Microsoft Intermediate Language)

All .NET languages compile to MSIL
![](images/csharpcompiling.png)

Use ILDASM to open the dlls

.NET runtime is responsible to run the MSIL or the .NET executables

With recent .NET Core runtime, you can run your program in Windows, Linux and Mac os platforms

Base Class Library
- Dates
- Math
- Strings
- File IO
- Data access
- TCP
- SMTP
- HTTP
- Arrays


Nuget packages
- Nuget.org is a platform to provide the versioning, developer information, library
- Nuget package manager can help create the library and install them in a project

`struct` type cannot inherit from base struct

`record` type from C# 9 fast gaining attractions, is useful for microservices and multilayer applications. Use it for immutable objects. It is used for data transfer objects

```
public class Employee: IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Id { get; set ; }

    <!-- public Employee() -->
    <!-- { -->
<!--  -->
    <!-- } -->

    public Employee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

public class Manager: Employee,IPerson
{
    public Manager():base("unknown","unknown")
    {

    }
    public int NumberOfDirectReports{get;set;}
}
```

One class can inherint multiple interfaces but one base class. Base class must have a default constructor (line 39-40). Other way to fix the compiling error is having line 53-56. Line 53-56 don't mean the program works, but just compiling.

Object initialization
```
Employee employeeTwo = new Employee
{   
    FirstName = "Qianshuang",
    LastName = "Zhang",
    Id = 56
};
```
Above will call the default constructor of `Employee`. Curly brace will set the properties

If the class property is given the `init`, it means it can only be set at the initialization stage.
```
public class PremierCustomer: Customer
{
    public PremierCustomer(byte level)
    {
        CustomerLevel = level;
    }
    public byte CustomerLevel {get; init;}
}

```
If a property has a `private` qualifier before setting, it means the property can only be set within the class.
```
public class PremierCustomer: Customer
{
    public PremierCustomer(byte level)
    {
        CustomerLevel = level;
    }
    public string NameOfTheCustomer {get; private set;}
    public byte CustomerLevel {get; init;}
    public void SetTheNameOfTheCustomer(string name)
    {
        NameOfTheCustomer = name;
    }
}
```
The property can only be set by calling `SetTheNameOfTheCustomer()` method.

With the `ref` keyword, if the variable with `ref` is passed to the method, when the variable is changed, the change will be persisted to the outside of the method. 

Without the `ref` keyword, only the object which reference is pointing to can be changed.

For the `struct`, if make a copy a struct object, the copy will create an entirely new object. If the struct object is passed to the method, it will just be the copy of the object the reference pointing to.

For the class type equality checking, it checks the reference, i.e. even the value is the same, differenct reference will result in false comparison. Struct and record are value type checking

Abstract class
- The properties can also be marked as `virtual` or `abstract`
    - `public virtual DateTime EndDate {get; set;}`

- The `abstract` method must be implemented in the derived class. There is no implementation in the base class

- The `virtual` method has implementation in the base class. The derived class can either override the method or have a new instance of the method

Static class
- Make a static constructor. It means when this class is firtly used the static constructor will be called. One can use the static class in on instances classes