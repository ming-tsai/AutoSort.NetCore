# NetCore.AutoSort ![build](https://github.com/ming-tsai/NetCore.AutoSort/workflows/build/badge.svg) ![nuget](https://github.com/ming-tsai/NetCore.AutoSort/workflows/nuget/badge.svg) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=ming-tsai_NetCore.AutoSort&metric=alert_status)](https://sonarcloud.io/dashboard?id=ming-tsai_NetCore.AutoSort) [![Conventional Commits](https://img.shields.io/badge/Conventional%20Commits-1.0.0-yellow.svg)](https://conventionalcommits.org) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Recently, I have a project that made with ef core, and every time I added some property I have to create a new condition for soring it,  so I want to sort the entity with a string or with some mark that could be used as default sorting, so I created this solution to manage this problem.

I was guiding by [ZZZ Projects's System.Linq.Dynamic](https://github.com/zzzprojects/System.Linq.Dynamic)

## Install the package
Using dotnet cli
```cmd
dotnet add package AutoSort --version 1.0.6
```
Or package manager
```powershell
Install-Package AutoSort -Version 1.0.6
```

## How to use?
### Sorting with a string
#### Import the library
```csharp
using NetCore.AutoSort;
```
#### Applying the sort with string
The valid sorting combinations are: `${PropertyName}` + `ascending, _asc, asc, descending, _desc, desc`

See below example:
```csharp
var people = dbContext.People.AsQueryable();
// BirthDay will apply ascending
var sorted = people.ApplySort("FirstName asc, LastName_desc, BirthDay");
```
### Set default sort attribute
When applying the sort but didn't pass parameter `sortBy` it will take configuration of model.

#### Import the library
```csharp
using NetCore.AutoSort.Attributes;
using NetCore.AutoSort.Enums;
```
#### Adding attibute to model properties
```csharp
public Hero
{
    // this will be the last sort and ascending
    [Sort(2)]
    public int Id { get; set; }
    // this will be sort first one and descending
    [Sort(SortDirection.Descending)]
    public string Name { get; set; }
    // this will sort in second one ascending
    [Sort(1)]
    public string History { get; set; }
}
```

> More example in [AutoSort.Example](https://github.com/ming-tsai/NetCore.AutoSort/blob/master/src/NetCore.AutoSort.Example/Program.cs)

## License
This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details
