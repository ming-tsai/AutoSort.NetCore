# NetCore.AutoSort ![build](https://github.com/ming-tsai/NetCore.AutoSort/workflows/build/badge.svg) ![nuget](https://github.com/ming-tsai/NetCore.AutoSort/workflows/nuget/badge.svg) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=ming-tsai_AutoSort.NetCore&metric=alert_status)](https://sonarcloud.io/dashboard?id=ming-tsai_AutoSort.NetCore) [![Conventional Commits](https://img.shields.io/badge/Conventional%20Commits-1.0.0-yellow.svg)](https://conventionalcommits.org) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Recently, I have a project that made with ef core, and every time I added some property I have to create a new condition for soring it,  so I want to sort the entity with a string or with some mark that could be used as default sorting, so I created this solution to manage this problem.

I was guiding by [ZZZ Projects's System.Linq.Dynamic.Core](https://github.com/zzzprojects/System.Linq.Dynamic.Core)

## Install the package
Using dotnet cli
```cmd
dotnet add package AutoSort.NetCore
```
Or package manager
```powershell
Install-Package AutoSort.NetCore
```

## How to use?

### Set default sort attribute
When applying the sort but didn't pass parameter `ordering` it will take configuration of model.

### Import the library
```csharp
using NetCore.AutoSort;
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

> More example in [AutoSort.Example](./src/AutoSort.Example/Program.cs)
## License
This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details
