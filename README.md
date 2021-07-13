
# MVC (Model-View-Controller) 

É um padrão arquitetural, baseado em 3 camadas (Model, View e Controller)

"Tem-se uma arquitetura que trabalha com o padrão".

Um estilo de arquitetura é aplicado para o sistema inteiro, já um padrão atua em cima de uma arquitetura existente.

**Camadas**

*Model* - É a camada de negócio do projeto. Pode conter: regras de negócio, entidades, camada de acesso a dados etc.

*View* - É responsável por renderizar a resposta (O response de uma aplicação, em geral, é enviado pela View). Pode conter: arquivos html.

*Controller* - É responsável por controlar o fluxo de dados entre View e Model. (Os requests de uma aplicação são recebidos pelo Controller).

***

## Controller

### Funções
	- Gerenciar o fluxo de dados.
	- Configurar as rotas.
	- Definir o tipo de saída (IActionResults).

### Convenções
	- Nome da classe controller deve possuir o sufixo "Controller"

	- As IActionResults devem ter o mesmo nome das Views que serão retornadas.

### Rotas

São os caminhos em uma URL, representam uma estrutura lógica que atende as necessidades de passagem de parâmetros.

Na classe Startup podemos configurar tanto a rota padrão como rotas alternativas.

```C# 
// Rota Padrão
endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```
```C# 
// Rota Alternativa (Não é comum, configuração de rotas é mais usual no Controller)
endpoints.MapControllerRoute(
    name: "categoria",
    pattern: "{controller=Home}/{action=Index}/{id}/{categoria?}");
```

Nas classes Controllers podemos também configurar as rotas e os parâmetros recebidos por elas:

```C# 
// Configuração de rota nas classes Controllers

[Route("")] // rota vazia
[Route("rota-index")] //sobrecarga da rota.
[Route("rota-index/{id:guid}/numero:int")] // rota com atributos e definição do tipo de dado.
```

**Sobrecarga de rotas**

Pode ser definido mais de uma rota, neste caso as diferentes rotas levarão ao mesmo lugar.

**Parâmetros nas rotas**

É uma maneira mais flexivel e facil de personalizar as rotas, valem apenas para a Controller e IActionResult que foi configurada. 

	- Previnindo conflitos
	Ao passar parâmetros através das rotas, os argumentos na IActionResult devem possuir o mesmo nome. Do contrário a aplicação não irá interpretar.

	Caso haja um parâmetro na IActionResult que não esteja especificada na rota (ou com o nome incorreto) pode-se forçar a atribuição pela maneira convencional do HTTP (?nomeParametro=valorAtrobuido). (Não é recomendável).

**Rotas vazias**

Uma rota vazia será utilizada quando não houver o caminho especificado na URL.

	- Prevenindo conflitos
	Para evitar conflitos de interpretação uma rota vazia pode ser atribuída a apenas uma Controller, do contrário haverá conflito na aplicação para saber qual retorno enviar.
	De forma análoga, dentro das Controllers apenas uma IActionResult pode receber uma rota vazia.

### IActioResult

É o tipo de retorno do Controller através da interface IActionResult.

Há vários tipos de retornos que podem ser enviados como View, JSON etc.

***

