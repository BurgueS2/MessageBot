# Como configurar o projeto

Para configurar o projeto, siga os passos abaixo:


## 1. Clone o repositório

```bash
git clone https://github.com/BurgueS2/MessageBot.git
```
## 2. Instalar dependências

Instale os pacotes necessários com o NuGet:

``` bash
dotnet add package Google.Apis.Calendar.v3
dotnet add package Twilio
dotnet add package Quartz 
```

## 3. Configurar a Google Calendar API

1. Crie um projeto no Google Cloud Console.
2. Ative a Google Calendar API no projeto.
3. Baixe o arquivo `credentials.json` e coloque-o na raiz do projeto.

## 4. Configurar o Twilio

1. Crie uma conta no Twilio.
2. Configure o WhatsApp Business Sandbox e obtenha o número do Twilio.
3. No código, insira suas credenciais do Twilio (`accountSid`, `authToken`) no arquivo de configuração, ou diretamente no código (de preferência, usando variáveis de ambiente).

## 5. Executar o projeto

Rode o projeto:

```bash
dotnet run
```

A primeira vez que o bot rodar, ele pedirá para autenticar na conta do Google via navegador. Depois da autenticação, ele salvará um token (`token.json`) para que o login não seja solicitado nas próximas execuções.
