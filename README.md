# Prueba técnica Yansel Martínez
Mi [GitHub](https://github.com/ymartinez7)
y [Linkedin](https://www.linkedin.com/in/ymartinez7/)

# Índice

1. [Resumen](#resumen)
2. [Descripción y comentarios generales de la aplicación](#descripción-y-comentarios-generales-de-la-aplicación)
3. [Ejecución de la aplicación](#ejecución-de-la-aplicación)
4. [Casos de uso](#casos-de-uso)
   - [Grapes](#grapes)
     - [Calcular área total por variedad de uva](#1-calcular-área-total-por-variedad-de-uva)
   - [Managers](#managers)
     - [Calcular área total administrada por cada gerente](#1-calcular-área-total-administrada-por-cada-gerente)
     - [Listar identificadores de Gerentes](#2-listar-identificadores-de-gerentes)
     - [Listar tax numbers de los gerentes ordenados alfabéticamente por nombre](#3-listar-tax-numbers-de-los-gerentes-ordenados-alfabéticamente-por-nombre)
   - [Vineyards](#vineyards)
     - [Listar los viñedos con sus respectivos gerentes](#1-listar-los-viñedos-con-sus-respectivos-gerentes)
5. [Testing](#testing)
   - [Pruebas Unitarias](#pruebas-unitarias)
     - [Caso de uso 1](#caso-de-uso-1)
     - [Caso de uso 2](#caso-de-uso-2)
     - [Caso de uso 3](#caso-de-uso-3)
   - [Prueba de integración](#prueba-de-integración)


## Resumen
Si bien la implementación de la solución del desafío planteado la pude haber hecho mucho más simple, usando una arquitectura mucho más básica e inyectando los repositorios directamente en los controladores o en su lugar creando servicios de aplicación para abstraer aún más las cosas, preferi en su lugar implementar algo más complejo, usado una arquitectura hexagonal y aplicando ciertas prácticas de desarrollo y algunos patrones de diseño.

## Descripción y comentarios generales de la aplicación

- **Versión de .NET**: La solución se construyó usando la versión 9 de .NET, especificamente la versión **9.0.100**. Se puede verificar esta información en el fichero **global.json** que contiene la solución.
- **Principios SOLID**: Se intentó seguir lo mejor posible los principios y buenas prácticas de desarrollo, tal como lo estipulan los princpios SOLID.
- **Arquitectura**: Se implementó para la solución una arquitectura hexagonal (puertos y adaptadores), compuesta por 4 capas (Domino, Application, Infrastructure y Api). Las capas Domino y Application son agnósticas de la infraestructura, presentación y de cualquier otra librería externa para evitar el acoplamiento fuerte o dependencias innecesarias.
- **Domain-Driven Design (DDD)**: Se aplicó en la solución algunos conceptos de DDD tales como value objects, entities, repositories, etc.
- **Mediator Pattern**: Se implementó en el proyecto del API el patrón mediador usando la librería MediatR, usando request y request handlers para segregar responsabilidades y organizar de una mejor manera el código.
- **Repository Pattern**: Se implementó el patrón de repositorio. La capa Domain solo expone las abstracciones (interfaces) y sus implementaciones se realizan en la capa de insfrastructure, usando EF Core para el acceso a los datos en una base de datos Sql Server.
- **Contenerización**: Ambas, Api y base de datos están contenerizados usando imágenes de docker y docker-compose para su ejecución simultánea.
- **Testing**: Para el testing, se usaron librerías tales como xUnit, MOQ, FluentAssertions, Testcontainers y Microsoft.AspNetCore.Mvc.Testing.

## Ejecución de la aplicación.

Para ejecutar la aplicación correctamente, se debe seleccionar desde visual studio el proyecto **docker-compose** como proyecto de inicio, para poder ejecutar la aplicación con sus dependencias, como lo es la base de datos sql server.

Luego de ejecutar la aplicación de esta manera, estará el swagger disponible para probarlo en la siguiente ruta: <https://localhost:8081/swagger/index.html>

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
### 1. Calcular área total por variedad de uva
**Endpoint: POST /grapes/area**

**Request**
```
POST /grapes/area
```

**Response** 
```json
{
  "Tempranillo": 3500,
  "Albariño": 9000,
  "Garnacha": 4000
}
```


## Managers
### 1. Calcvular área total administrada por cada gerente
**POST /managers/totalarea**

**Request**
```
POST /managers/totalarea
```

**Response** 
```json
{
  "Miguel Torres": 3500,
  "Ana Martín": 9000,
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
    "name": "Ana Martín"
  },
  {
    "id": 3,
    "name": "Carlos Ruiz"
  }
]
```

### 3. Listar tax numbers de los gerentes ordenados alfabéticamente por nombre 
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
    "name": "Ana Martín"
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
    "name": "Ana Martín"
  },
  {
    "taxNumber": "78903228",
    "name": "Carlos Ruiz"
  }
]
```

## Vineyards
### 1. Listar los viñedos con sus respectivos gerentes
**GET /vineyards/managers**

```
GET /vineyards/managers
```

**Response** 
```json
{
  "Bodegas Bilbaínas": [
    "Ana Martín",
    "Carlos Ruiz",
    "Miguel Torres"
  ],
  "Viña Esmeralda": [
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

### Prueba de integración
Proyecto de tests de integración: **Visiotech.VineyardManagementService.Api.IntegrationTests**


Pruebas de integración que validan los endpoints del controlador de managers.

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