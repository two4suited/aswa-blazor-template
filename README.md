# Azure Static Web Sites Starter App using Blazor and Azure Functions

This template contains an example [Blazor WebAssembly](https://docs.microsoft.com/aspnet/core/blazor/?view=aspnetcore-3.1#blazor-webassembly) client application, a C# [Azure Functions](https://docs.microsoft.com/azure/azure-functions/functions-overview) and a C# class library with shared code.

This template adds authentication to the [quickstart guide](https://aka.ms/blazor-swa/quickstart) 

It leverages methods from this [blog post](https://anthonychu.ca/post/blazor-auth-azure-static-web-apps/) from Anthony Chu

It also setups up Dependency Injection for Azure Functions.

## Getting Started

Create a repository from the [GitHub template](https://github.com/two4suited/aswa-blazor-template/generate) and then clone it locally to your machine.

Once you clone the project, open the solution in [Visual Studio](https://visualstudio.microsoft.com/vs/community/) and press **F5** to launch both the client application and the Functions API app.

_Note: If you're using the Azure Functions CLI tools, refer to [the documentation](https://docs.microsoft.com/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash) on how to enable CORS._

## Template Structure

* **Client**: The Blazor WebAssembly sample application
* **API**: A C# Azure Functions API, which the Blazor application will call
* **Shared**: A C# class library with a shared data model between the Blazor and Functions application

## Deploy to Azure Static Web Apps

This application can be deployed to [Azure Static Web Apps](https://docs.microsoft.com/azure/static-web-apps), to learn how, check out [our quickstart guide](https://aka.ms/blazor-swa/quickstart).
