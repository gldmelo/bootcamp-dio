# Apresentação

Esta é uma implementação em C# para utilização do serviço ``Image Analysis`` da ``Azure AI Vision`` para gerar uma descrição em texto para a imagem. Essa implementação é baseada no exemplo do Microsoft Learning e foi ajustado para rodar em um container Docker.

Link do exemplo original:
[Image Analysis 4.0](https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/quickstarts-sdk/image-analysis-client-library-40?tabs=visual-studio%2Cwindows&pivots=programming-language-csharp)

## Como testar

### Compilar o código na máquina local
```docker build -t azurecomputervisiondescreverimagem:dev -f Dockerfile ..```

### Executar o código usando o Docker
```docker run -it --env=VISION_ENDPOINT=SEU_ENDPOINT --env=VISION_KEY=SUA_KEY azurecomputervisiondescreverimagem:dev```

## Output

``Legenda (caption): "a man standing in front of a fish tank". Confiança: 0.8755``

## Onde encontro as informações de Endpoint e Key?

A partir do Vision Studio, após ter cadastrado o recurso conforme indicado no tutorial:
Link: [Vision Studio](https://portal.vision.cognitive.azure.com/demo/image-captioning)

![image](https://github.com/gldmelo/dio-lab-azure-ai-endpoint/assets/6453228/e98867ee-d1fe-4d46-a8e4-b893bdd8ddd2)
