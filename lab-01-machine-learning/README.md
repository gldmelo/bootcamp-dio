# Apresentação

Este foi um lab prática de utilização do serviço ``Automated ML`` da ``Azure Machine Learning`` para criar um modelo de previsão de preço de aluguel de bicicletas.

O objetivo do tutorial era criar um modelo contendo dados históricos e condições climáticas (estação do ano, temperatura, umidade do ar, velocidade do vento, entre outros), treinar esse modelo utilizando ``Aprendizado de Máquina Automatizado`` e por fim disponibilizar um endpoint para que o modelo pudesse ser consumido por uma aplicação externa.

Durante o tutorial o modelo foi treinado utilizando uma ``Random Forest`` para treinar o modelo de ``Regressão`` para prever o preço de aluguel de bicicletas em um dado dia considerando a previsão do tempo como parâmetro de entrada.

# Testando Azure AI Endpoint

## Seguir as instruções do passo a passo:
https://microsoftlearning.github.io/mslearn-ai-fundamentals/Instructions/Labs/01-machine-learning.html

## Importante
O arquivo JSON de teste fornecido no link não funciona mais pois o formato mudou e a MS ainda não atualizou o material de estudos (até 26/02/2024).

Após importar os dados do tutorial, treinar o modelo e criar o endpoint utilizar o arquivo ``test.json`` que forneci neste repositório.
