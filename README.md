# Bot para Envio de Alertas de Eventos do Google Calendar

## Descrição

Este projeto é um bot em C# que busca eventos do **Google Calendar** e envia alerta personalizados para um ou vários contato no **WhatsApp** utilizando a API do **Twilio**. O bot é agendado para verificar a agenda todos os dias e enviar mensagens em um horário específico, caso haja algum evento no Google Calendar para o dia.

## Motivação

Este projeto foi criado para facilitar a visualização de eventos do Google Calendar, enviando alerta diários para o WhatsApp. A ideia foi inspirada em um projeto pessoal para receber lembretes diários de eventos, com reservas de mesa em restaurantes, como tinha várias reservas e era muito manual, era difícil lembrar de todas, então criei este bot para me ajudar e ajudar outros funcionários, o bot envia uma mensagem com todos os eventos do dia e para vários contatos, assim todos recebem a mensagem e não esquecem de nada.


## Funcionalidades

- Conecta-se à API do Google Calendar para obter eventos.
- Envia mensagens via WhatsApp usando a API do Twilio.
- Agendamento diário automático para envio de mensagens.
- Mensagens personalizadas com eventos do Google Calendar.
- Configuração de horário de envio de mensagens.

## Requisitos

- .NET Core SDK (versão 3.1 ou superior)
- Conta no **Google Cloud Platform** com a **Google Calendar API** ativada.
- Conta no **Twilio** para enviar mensagens via WhatsApp.

## Configuração

Acesse o arquivo [SETUP.md](SETUP.md) para instruções de configuração.

## Estrutura do Projeto

- **CalendarService.cs**: gerencia a conexão com o Google Calendar e busca os eventos.
- **MessengerService.cs**: utiliza a API do Twilio para enviar mensagens de WhatsApp.
- **SchedulerService.cs**: Usa o Quartz.NET para agendar o envio diário das mensagens.
- **Program.cs**: ponto de entrada do programa que inicializa o agendador.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo [LICENSE.md](LICENSE) para mais detalhes.