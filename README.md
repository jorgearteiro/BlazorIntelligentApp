# BlazorIntApp1

Demo Azure Open AI app using .NET Blazor Server template.

## Prerequisites

The application Ai Chat menu option requires an Azure Open AI subscription with "gpt-4o" model deployed.
Please, create these secrets on the Kubernetes Namespace of your application deployment, like as showing here:

```bash
kubectl create secret generic azure-openai-url --from-literal=AZURE_OPENAI_API_URL=<your Azure Open AI URL here> -n blazorintapp1

kubectl create secret generic azure-openai-key --from-literal=AZURE_OPENAI_API_KEY=<your Azure Open AI Key here> -n blazorintapp1
```

In development, you can use the dotnet secrets to store your App secrets.
In Visual Studio, right-click the project in Solution Explorer, and select Manage User Secrets from the context menu.
Add your secrets as showing here:
```json
{
  "AzureOpenAIUrl": "<your Azure Open AI URL here>",
  "AzureOpenAIKey": "<your Azure Open AI Key here>"
}
```

## Running the app with a Load Balancer service

If you want to create a Load Balancer service to your app, replace the whole manifest/service.yaml file with the following yaml:
```yaml
apiVersion: v1
kind: Service
metadata:
  name: blazorintapp1
  namespace: blazorintapp1
  labels:
    kubernetes.azure.com/generator: devhub
spec:
  type: LoadBalancer
  selector:
    app: blazorintapp1
  ports:
    - protocol: TCP
      port: 80
      targetPort: 8080
```