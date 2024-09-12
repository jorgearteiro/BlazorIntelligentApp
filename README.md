# BlazorIntApp1

Demo Azure Open AI app using .NET Blazor Server template.

Requirements: 
Create these secrets on the Kubernetes Namespace of your application deployment, like as showing here:

```bash
kubectl create secret generic azure-openai-url --from-literal=AZURE_OPENAI_API_URL=<your Azure Open AI URL here> -n blazorintapp1

kubectl create secret generic azure-openai-key --from-literal=AZURE_OPENAI_API_KEY=<your Azure Open AI Key here> -n blazorintapp1
```
