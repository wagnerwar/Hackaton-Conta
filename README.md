

## Instruções de instalação

É necessário que você tenha instalado o Visual Studio 2019 ou o Visual Studio Code.
Feito isso, é só baixar o projeto, compilar (Clique direito sobre o projeto -> Build Project) e rodar (Selecionar IIS Express).  
 OBS: Caso esteja usando o Visual Studio Code, é necessário adicionar alguns complementos ao editor para que o mesmo possa executar projetos em .net core (https://code.visualstudio.com/docs/languages/dotnet).
 

## Informações adicionais

Esta aplicação consome alguns serviços cognitivos da Azure (TextAnalytic e Speech). Portanto, para usá-los é necessário configurar as credenciais de autenticação na Azure para usá-las na aplicação. 
Tendo estas credenciais, em cada chamada, deve-se incluir estas chaves na instância de um dos serviços do Azure.


