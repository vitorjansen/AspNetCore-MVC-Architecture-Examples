
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

### IActionResult

É o tipo de retorno do Controller através da interface IActionResult.

Há vários tipos de retornos que podem ser enviados como View, JSON etc.

***

## Model

### Funções
    - Uma Model é uma classe que representa uma entidade do mundo real.

    - No geral, a Model representa uma tabela no banco de dados.

### DTO (Data Transfer Object)

É a classe que unifica um conjunto de informações, de diferentes Models, utilizada para diminuir o número de requisições no servidor.

### Annotations

É um recurso com com as seguintes utilidades:

- Especifica o tipo de dado que a propriedade deve receber.
- Define o tamanho, padrão e a obrigatoriedade do preenchimento.
- Podem ser utilizadas para mapear tipos e tamanho das colunas no banco de dados.
- Permite fazer validação de formulários nas Razor Views.
- Ao passar por uma validação, garante que as especificações foram atendidas.

Obs.: Não há limite de Annotation que uma propriedade pode ter.

Exemplo de seu uso:
```C#
// Annotation sem atributos
[Required()]
// Annotation com 1 atributo.
[Required(ErrorMessage = "O campo Título é obrigatório")]
// Annotation com 2 atributo.
[StringLength(60, MinimumLength = 3, ErrorMessage = "O titulo pecisa ter entre 3 e 60 caracteres.")]
// Propriedade que receberá as Annotations
public string Titulo { get; set; }
```
É possível também fazer sobrecargas em Annotations. (Não é usual, pois não altera as funcionalidades, muda apenas visualmente)
```C#
//Sobrecarga
[RegularExpression(@"^[A-Z]"), Required(ErrorMessage = "Este campo é obrigatório")]

```
[Referência com os tipos de Annotations existentes](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-5.0)


### Validações

A Model possui um dicionário chamado `ModelState` que reprenta as informações enviadas no HTTP para serem processadas.

Nele podemos usar o atributo `ModelState.IsValid` para validar as entradas de dados e usar o `ModelState.Values` para capturar cada uma das validações feitas.

***

## View

Convenções

	- Cada Controller deve ter sua subpasta (com o mesmo nome da classse) na pasta de Views.

	- "_" Antes do nome da View, significa que é uma View complementar, ou seja, que trabalha em conjuto com outros arquivos.

### Arquivos da Views

**Raiz da pasta View**

*_ViewStart*: Define as configurações iniciais a serem utilizadas. (Layout, por exemplo). É possível usar instruções como `if-else`. 

*_ViewImports*: Faz a importação dos arquivos necessários como namespaces, tag helpers, tag helpers personalizados etc.

*_CookieConsentPartial*: Gerencia o consentimento da utilização dos cookies.

*_ValidationScriptsPartial*: Inclui arquivos para execução de scripts como javascript.

**Pasta Shared**

São os arquivos que serão reutilizados no projeto inteiro (página de erro e layout, por exemplo).

*_Layout*: Página de Layout. (Estrutura HTML principal).

*Error*: Página de erro.

### Razor Views

O motor de renderização das Views chama-se Razor. Portanto, Razor Views São arquivos HTML mesclados com recursos do Razor.

Além de renderizar as páginas, também ajuda na criação de componentes HTML ([Tag Helpers](#tag-helpers)), tornando mais produtiva a construção das páginas.

### Tag Helpers

São os recursos para geração de HTML.

### View Components

São componentes que podem ser integrados às Views e trabalham de forma independente de um modelo específico e que podem realizar consulta e processamento de dados.

### Partial Views

São pedaços de uma View. Utilizadas para reaproveitar código.