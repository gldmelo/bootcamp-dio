# Apresentação

Esta é uma implementação em C# para utilização do recurso ``Text Analytics`` da ``Azure AI Language`` para *Análise de Sentimento*, ou seja indicar se um texto de entrada reflete um sentimento positivo, neutro ou negativo, bem como um percentual de confiança do algoritmo nesta seleção. Essa implementação é baseada no exemplo do github do Azure SDK para .NET e foi ajustado para rodar em um container Docker.

Link do exemplo original:
[Text Analytics](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics)

## Como testar

### Compilar o código na máquina local
```docker build -t azure-sentimentanalysis:dev -f Dockerfile ..```

### Executar o código usando o Docker
Informe uma frase na linha de comando para ser analisada. Exemplo:

```docker run -it --rm --env=LANGUAGE_ENDPOINT=SEU_ENDPOINT --env=LANGUAGE_KEY=SUA_KEY azure-sentimentanalysis:dev "Pratos variados e preços acessíveis. A vista é incrível e foi o que mais gostamos."```

## Output

```
Sentimento do texto é: Positivo
Score de confiança Positivo: 0.95
Score de confiança Neutro: 0.05
Score de confiança Negativo: 0
```

## Onde encontro as informações de Endpoint e Key?

A partir do Language Studio, após ter cadastrado o recurso conforme indicado no tutorial:
Link: [Language Studio](https://language.cognitive.azure.com/tryout/sentiment)

![image](https://github.com/gldmelo/dio-lab-azure-ai-endpoint/assets/6453228/c77da226-cc33-4f36-93db-49d30fe898c2)
