# Apresentação

Esta é uma implementação em C# para utilização do recurso ``Cognitive Search`` da ``Azure AI Search`` para busca dentro de documentos previamente armazenados em um container da Azure e indexados utilizando os recursos de IA disponíveis. Essa implementação é baseada no exemplo do github do Azure SDK para .NET e foi ajustado para rodar em um container Docker.

Neste exemplo vamos consultar as avaliações feitas por clientes de uma cafeteria para encontrar as avaliações negativas.

Link do tutorial de configuração:
[AI Search](https://microsoftlearning.github.io/mslearn-ai-fundamentals/Instructions/Labs/11-ai-search.html)

## Como testar

### Compilar o código na máquina local
```docker build -t azure-document-search:dev -f Dockerfile ..```

### Executar o código usando o Docker
Informe uma frase na linha de comando para ser analisada. Exemplo:

```docker run -it --rm --env=SEARCH_ENDPOINT=SEU_ENDPOINT --env=SEARCH_API_KEY=SUA_KEY azure-document-search:dev```

## Output

![image](https://github.com/gldmelo/dio-lab-azure-ai-endpoint/assets/6453228/89ed9e5c-7ad3-4ba4-a55e-2a20cc43eb20)


## Onde encontro as informações de Endpoint e Key?

A partir do Azure AI Search, após ter cadastrado o recurso conforme indicado no tutorial:
Link: [Azure AI Search](https://portal.azure.com/#view/Microsoft_Azure_ProjectOxford/CognitiveServicesHub/~/CognitiveSearch)


