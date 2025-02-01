
## Como utilizar o Azure Container Registry para fazer o deploy de uma API no Azure Web Apps

### Clonar o repositório do GitHub
`git clone https://github.com/gldmelo/dio-az204-lab-azure-api.git`

## Montar a imagem localmente na máquina
`docker build -t lab-az204-api:latest .`

### Envio da imagem para o Azure Container Registry (ACR)
Acessar pelo Azure Portal a tela de Access Keys do ACR e habilitar o `Admin user`.
![image](https://github.com/gldmelo/dio-az204-lab-azure-api/blob/main/assets/access-keys.png?raw=true)

Uma vez configurado devemos executar o comando abaixo, mudando o `az2024labapi` para o nome do ACR correspondente.
`docker login az2024labapi.azurecr.io`

Utilize o usuário e senha configurados na tela de Access Keys do Azure Portal.
Depois execute o comando abaixo para gerar uma Tag da imagem na máquina para uma tag no ACR.
`docker tag lab-az204-api:latest az2024labapi.azurecr.io/lab-az204-api:latest`

e por fim envie a imagem para o ACR com o seguinte comando:
`docker push az2024labapi.azurecr.io/lab-az204-api:latest`

### Criação do Web App
O último passo é criar o Web App pelo Azure Portal, selecionando o modo Publish como Container, e na tela de container selecionar a origem como Azure Container Registry.

### Limpando os recursos ao final do Lab
Não esqueça de excluir o Resource Group ao final do lab para evitar cobranças não planejadas!
