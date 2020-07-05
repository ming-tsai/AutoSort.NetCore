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
## Contributors
[![](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/images/0)](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/links/0)[![](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/images/1)](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/links/1)[![](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/images/2)](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/links/2)[![](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/images/3)](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/links/3)[![](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/images/4)](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/links/4)[![](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/images/5)](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/links/5)[![](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/images/6)](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/links/6)[![](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/images/7)](https://sourcerer.io/fame/ming-tsai/ming-tsai/AutoSort.NetCore/links/7)
## License
This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details
