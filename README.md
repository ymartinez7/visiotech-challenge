# Prueba t�cnica Yansel Mart�nez
Mi [GitHub](https://github.com/ymartinez7)
y [Linkedin](https://www.linkedin.com/in/ymartinez7/)

# �ndice

1. [Resumen](#resumen)
2. [Descripci�n y comentarios generales de la aplicaci�n](#descripci�n-y-comentarios-generales-de-la-aplicaci�n)
3. [Ejecuci�n de la aplicaci�n](#ejecuci�n-de-la-aplicaci�n)
4. [Casos de uso](#casos-de-uso)
   - [Grapes](#grapes)
     - [Calcular �rea total por variedad de uva](#1-calcular-�rea-total-por-variedad-de-uva)
   - [Managers](#managers)
     - [Calcular �rea total administrada por cada gerente](#1-calcular-�rea-total-administrada-por-cada-gerente)
     - [Listar identificadores de Gerentes](#2-listar-identificadores-de-gerentes)
     - [Listar tax numbers de los gerentes ordenados alfab�ticamente por nombre](#3-listar-tax-numbers-de-los-gerentes-ordenados-alfab�ticamente-por-nombre)
   - [Vineyards](#vineyards)
     - [Listar los vi�edos con sus respectivos gerentes](#1-listar-los-vi�edos-con-sus-respectivos-gerentes)
5. [Testing](#testing)
   - [Pruebas Unitarias](#pruebas-unitarias)
     - [Caso de uso 1](#caso-de-uso-1)
     - [Caso de uso 2](#caso-de-uso-2)
     - [Caso de uso 3](#caso-de-uso-3)
   - [Prueba de integraci�n](#prueba-de-integraci�n)


## Resumen
Si bien la implementaci�n de la soluci�n del desaf�o planteado la pude haber hecho mucho m�s simple, usando una arquitectura mucho m�s b�sica e inyectando los repositorios directamente en los controladores o en su lugar creando servicios de aplicaci�n para abstraer a�n m�s las cosas, preferi en su lugar implementar algo m�s complejo, usado una arquitectura hexagonal y aplicando ciertas pr�cticas de desarrollo y algunos patrones de dise�o.

## Descripci�n y comentarios generales de la aplicaci�n

- **Versi�n de .NET**: La soluci�n se construy� usando la versi�n 9 de .NET, especificamente la versi�n **9.0.100**. Se puede verificar esta informaci�n en el fichero **global.json** que contiene la soluci�n.
- **Principios SOLID**: Se intent� seguir lo mejor posible los principios y buenas pr�cticas de desarrollo, tal como lo estipulan los princpios SOLID.
- **Arquitectura**: Se implement� para la soluci�n una arquitectura hexagonal (puertos y adaptadores), compuesta por 4 capas (Domino, Application, Infrastructure y Api). Las capas Domino y Application son agn�sticas de la infraestructura, presentaci�n y de cualquier otra librer�a externa para evitar el acoplamiento fuerte o dependencias innecesarias.
- **Domain-Driven Design (DDD)**: Se aplic� en la soluci�n algunos conceptos de DDD tales como value objects, entities, repositories, etc.
- **Mediator Pattern**: Se implement� en el proyecto del API el patr�n mediador usando la librer�a MediatR, usando request y request handlers para segregar responsabilidades y organizar de una mejor manera el c�digo.
- **Repository Pattern**: Se implement� el patr�n de repositorio. La capa Domain solo expone las abstracciones (interfaces) y sus implementaciones se realizan en la capa de insfrastructure, usando EF Core para el acceso a los datos en una base de datos Sql Server.
- **Contenerizaci�n**: Ambas, Api y base de datos est�n contenerizados usando im�genes de docker y docker-compose para su ejecuci�n simult�nea.
- **Testing**: Para el testing, se usaron librer�as tales como xUnit, MOQ, FluentAssertions, Testcontainers y Microsoft.AspNetCore.Mvc.Testing.

## Ejecuci�n de la aplicaci�n.

Para ejecutar la aplicaci�n correctamente, se debe seleccionar desde visual studio el proyecto **docker-compose** como proyecto de inicio, para poder ejecutar la aplicaci�n con sus dependencias, como lo es la base de datos sql server.

Luego de ejecutar la aplicaci�n de esta manera, estar� el swagger disponible para probarlo en la siguiente ruta: <https://localhost:8081/swagger/index.html>

**docker-compose.yml**
```yml
services:

  visiotech.vineyardmanagementservice.api:
    image: ${DOCKER_REGISTRY-}visiotechvineyardmanagementserviceapi
    build:
      context: .
      dockerfile: src/Visiotech.VineyardManagementService.Api/Dockerfile
    ports:
      - "8081:8081"
    environment:
      - ASPNETCORE_URLS=https://+:8081
      - ASPNETCORE_ENVIRONMENT=Development
    depends_on:
      - sql-server

  sql-server:
    container_name: sql-server
    image: mcr.microsoft.com/mssql/server:latest
    environment:
      ACCEPT_EULA: "Y"
      SA_PASSWORD: NuevaContra123#
    ports:
      - "1433:1433"
    volumes:
      - dbdata:/var/opt/mssql

volumes:
  dbdata:
```

## Casos de uso
## Grapes
### 1. Calcular �rea total por variedad de uva
**Endpoint: POST /grapes/area**

**Request**
```
POST /grapes/area
```

**Response** 
```json
{
  "Tempranillo": 3500,
  "Albari�o": 9000,
  "Garnacha": 4000
}
```


## Managers
### 1. Calcvular �rea total administrada por cada gerente
**POST /managers/totalarea**

**Request**
```
POST /managers/totalarea
```

**Response** 
```json
{
  "Miguel Torres": 3500,
  "Ana Mart�n": 9000,
  "Carlos Ruiz": 4000
}
```

### 2. Listar identificadores de Gerentes
**GET /managers/ids**

**Request**
```
GET /managers/ids
```

**Response** 
```json
[
  {
    "id": 1,
    "name": "Miguel Torres"
  },
  {
    "id": 2,
    "name": "Ana Mart�n"
  },
  {
    "id": 3,
    "name": "Carlos Ruiz"
  }
]
```

### 3. Listar tax numbers de los gerentes ordenados alfab�ticamente por nombre 
**GET /managers/taxnumbers?sorted=true**

**Datos ordenados por nombre del gerente**

**Request**
```
GET /managers/taxnumbers?sorted=true
```

**Response** 
```json
[
  {
    "taxNumber": "143618668",
    "name": "Ana Mart�n"
  },
  {
    "taxNumber": "78903228",
    "name": "Carlos Ruiz"
  },
  {
    "taxNumber": "132254524",
    "name": "Miguel Torres"
  }
]
```

**Datos sin orden**
 

**Request**
```
GET /managers/taxnumbers?sorted=false
```

**Response** 
```json
[
  {
    "taxNumber": "132254524",
    "name": "Miguel Torres"
  },
  {
    "taxNumber": "143618668",
    "name": "Ana Mart�n"
  },
  {
    "taxNumber": "78903228",
    "name": "Carlos Ruiz"
  }
]
```

## Vineyards
### 1. Listar los vi�edos con sus respectivos gerentes
**GET /vineyards/managers**

```
GET /vineyards/managers
```

**Response** 
```json
{
  "Bodegas Bilba�nas": [
    "Ana Mart�n",
    "Carlos Ruiz",
    "Miguel Torres"
  ],
  "Vi�a Esmeralda": [
    "Carlos Ruiz",
    "Miguel Torres"
  ]
}
```

## Testing
### Pruebas Unitarias

Proyecto de tests unitarios: **Visiotech.VineyardManagementService.Application.UnitTests**

Pruebas unitarias que validan los casos de uso para manager.

**Caso de uso 1**
```cs
using Microsoft.Extensions.Logging;
using Moq;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.CalculateTotalManagementAreaByManager;
using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UnitTests.UseCases.Managers
{
    public class CalculateTotalManagedAreaUseCaseShould
    {
        private readonly Mock<ILogger<CalculateTotalManagedAreaUseCase>> _loggerMock;
        private readonly Mock<IManagerRepository> _managerRepositoryMock;
        private readonly Mock<ICalculateTotalManagedAreaOutputPort> _outputPort;
        private readonly CalculateTotalManagedAreaUseCase _calculateTotalManagedAreaUseCase;

        public CalculateTotalManagedAreaUseCaseShould()
        {
            _loggerMock = new Mock<ILogger<CalculateTotalManagedAreaUseCase>>();
            _managerRepositoryMock = new Mock<IManagerRepository>();
            _outputPort = new Mock<ICalculateTotalManagedAreaOutputPort>();

            _calculateTotalManagedAreaUseCase = new CalculateTotalManagedAreaUseCase(
                _loggerMock.Object,
                _managerRepositoryMock.Object,
                _outputPort.Object);
        }

        [Fact]
        public async Task Execute_ShouldExecuteUseCase()
        {
            // Arrange
            var input = new CalculateTotalManagedAreaInput();
            var managementAreasByManagers = new Dictionary<string, int>
                            {
                                { "Manager A", 150 },
                                { "Manager B", 200 },
                                { "Manager C", 250 }
                            };

            _managerRepositoryMock
                .Setup(r => r.GetTotalManagementAreaByManagerAsync())
                .ReturnsAsync(managementAreasByManagers);

            // Act
            await _calculateTotalManagedAreaUseCase.Execute(input);

            // Assert
            _managerRepositoryMock.Verify(m => m.GetTotalManagementAreaByManagerAsync(), Times.Once);
        }
    }
}

```

**Caso de uso 2**
```cs
using Microsoft.Extensions.Logging;
using Moq;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds;
using Visiotech.VineyardManagementService.Domain.Models;
using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UnitTests.UseCases.Managers
{
    public class ListAllManagerIdsUseCaseShould
    {
        private readonly Mock<ILogger<ListAllManagerIdsUseCase>> _loggerMock;
        private readonly Mock<IManagerRepository> _managerRepositoryMock;
        private readonly Mock<IListAllManagerIdsOutputPort> _outputPort;
        private readonly ListAllManagerIdsUseCase _listAllManagerIdsUseCase;

        public ListAllManagerIdsUseCaseShould()
        {
            _loggerMock = new Mock<ILogger<ListAllManagerIdsUseCase>>();
            _managerRepositoryMock = new Mock<IManagerRepository>();
            _outputPort = new Mock<IListAllManagerIdsOutputPort>();

            _listAllManagerIdsUseCase = new ListAllManagerIdsUseCase(
                _loggerMock.Object,
                _managerRepositoryMock.Object,
                _outputPort.Object);
        }

        [Fact]
        public async Task Execute_ShouldExecuteUseCase()
        {
            // Arrange
            var input = new ListAllManagerIdsInput();
            var managerIds = new List<ManagerIdInfo> {
                new(101, "Manager 1"),
                new(202, "Manager 2"), 
                new(303, "Manager 3") 
            };

            _managerRepositoryMock
                .Setup(r => r.GetAllManagerIdsAsync())
                .ReturnsAsync(managerIds);

            // Atc
            await _listAllManagerIdsUseCase.Execute(input);

            // Assert
            _managerRepositoryMock.Verify(m => m.GetAllManagerIdsAsync(), Times.Once);
        }
    }
}

```

**Caso de uso 3**
```cs
using Microsoft.Extensions.Logging;
using Moq;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers;
using Visiotech.VineyardManagementService.Domain.Models;
using Visiotech.VineyardManagementService.Domain.Repositories;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Application.UnitTests.UseCases.Managers
{
    public class ListAllManagerTaxNumberUseCaseShould
    {
        private readonly Mock<ILogger<ListAllManagerTaxNumberUseCase>> _loggerMock;
        private readonly Mock<IManagerRepository> _managerRepositoryMock;
        private readonly Mock<IListAllManagerTaxNumbersOutputPort> _outputPort;
        private readonly ListAllManagerTaxNumberUseCase _listAllManagerTaxNumberUseCase;

        public ListAllManagerTaxNumberUseCaseShould()
        {
            _loggerMock = new Mock<ILogger<ListAllManagerTaxNumberUseCase>>();
            _managerRepositoryMock = new Mock<IManagerRepository>();
            _outputPort = new Mock<IListAllManagerTaxNumbersOutputPort>();

            _listAllManagerTaxNumberUseCase = new ListAllManagerTaxNumberUseCase(
                _loggerMock.Object,
                _managerRepositoryMock.Object,
                _outputPort.Object);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Execute_ShouldExecuteUseCase(bool sorted)
        {
            // Arrange
            var input = new ListAllManagerTaxNumbersInput(sorted);

            var managerTaxNumbers = new List<ManagerTaxNumberInfo> { 
                new(new TaxNumber("101"), "Manager 1"), 
                new(new TaxNumber("202"), "Manager 2"), 
                new(new TaxNumber("303"), "Manager 3")
            };

            _managerRepositoryMock
                .Setup(r => r.GetAllManagerTaxNumbersAsync(sorted))
                .ReturnsAsync(managerTaxNumbers);

            // Act
            await _listAllManagerTaxNumberUseCase.Execute(input);

            // Assert
            _managerRepositoryMock.Verify(m => m.GetAllManagerTaxNumbersAsync(sorted), Times.Once);
        }
    }
}

```

### Prueba de integraci�n
Proyecto de tests de integraci�n: **Visiotech.VineyardManagementService.Api.IntegrationTests**


Pruebas de integraci�n que validan los endpoints del controlador de managers.

```cs
using FluentAssertions;
using System.Net;
using System.Text;
using System.Text.Json;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.CalculateTotalManagementAreaByManager;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllIds;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllTaxNumbers;
using Visiotech.VineyardManagementService.Api.IntegrationTests.Infrastructure;

namespace Visiotech.VineyardManagementService.Api.IntegrationTests.Controllers
{
    public class ManagersControllerShould(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task ListAllManagersIds_ShouldReturnAnIdsListOfManagers()
        {
            // Act
            HttpResponseMessage response = await HttpClient.GetAsync("managers/ids");

            // Assert
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<ListAllManagerIdsResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNull().And.HaveCount(3);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ListAllManagerTaxNumbers_ShouldReturnATaxNumberListOfManagers(bool sorted)
        {
            // Act
            HttpResponseMessage response = await HttpClient.GetAsync($"managers/taxnumbers?sorted={sorted}");

            // Assert
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<ListAllManagerTaxNumberResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task CalculateTotalManagementAreaByManager_ShouldReturnATotalAreaManagementByEachManager()
        {
            // Arrange
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(new CalculateTotalManagementAreaByManagerRequest()),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            HttpResponseMessage response = await HttpClient.PostAsync("managers/totalarea", jsonContent);

            // Assert
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNull().And.HaveCount(3);
        }
    }
}

```