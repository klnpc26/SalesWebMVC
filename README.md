**ASP.NET Core MVC e Entity Framework**

- View Models: Modelos auxiliares que são utilizados para povoar as nossas telas

- Template Engime: Vai montar para a gente a página de resposta e a resposta que dele irá
retornar para o navegador, vai ser em HTML, ou seja, já vai retornar a tela montada, diferente,
do Web Service que faz uma requisição para servidor e retorna apenas os dados necessários e 
na tela que teremos que montar o html.

- Responsabilidades no MVC:
    - Model: Estrutura dos dados e suas transformações (domain model)
	       - Também chamdo de "o sistema"
		   - Composto de Entities e Services (realcionados ás entities)
				- Repositories (Objetos que acessam dados persistentes)
	- Controllers: Receber e tratar as interações do usuário com o sistema
	- Views: Definir a estrutura e comportamento das telas.

- Nivelamento Entity Framework:
	- Problema: Por muitos anos, uma grande difiuldade de se criar sistemas orientados a 
	objetos foi a comunicação com o banco de dados relacional. 
	(30% do esforço de se fazer um sistema)
	
	Se quisermos implementar um acesso a dados bem feito, tem outras questões que devem ser
	traadas:
		- Contexto de persistência (monitorar alterações no objetos que estão atrelados
		a uma conexão em um dado momento)
			* Alterações
			* Transação
			* Concorrência
		- Mapa de identidade (cache de objeto já carregados)
		- Carregamento tardio (lazy loading). Ex: Se eu buscar um objeto, que ele
		tenha uma relação para muitos, eu não posso carregar automaticamente esses muitos
		objetos que estão associados a ele, precisamos fazer um controle tardio para só
		carregarmos quando precisarmos.
		- Etc. 
	- Solução: Mapeamento Objeto-Relacional (ORM)
		- ORM (Object-Relational Mapping): Permite programar em nível de objetos e comunicar
		de forma transparente com um banco de dados relacional.
	- Principais Classes
		- DbContext: Um objeto DbContext encapsula uma sessão com o banco de dados
		para um determinado modelo de dados (presentado por DbSet's).
			* É uma combinação dos padrões Unity of Work e Repository
				* Unity of Work: "Mantém uma lista de objetos afetados por uma transação e
				coordena a escrita de mudanças e trata possíveis problemas de concorrência"
				* Repository: Define um objeto capaz de realizar operações de acesso a dados (consultar,
				salvar, atualizar, deletar) para uma entidade
		- DbSet<TEntity>: Representa a coleção de entidades de um dado tipo em um contexto.
		Tipicamente corresponde a uma tabela do banco de dados.

- wwwroot: Recursos do Front-End

- cshtml (Razor): é um formato especifico de tamplete que ele vai aceitar, tanto as marcações
HTML quanto o código C#

- Shered (Compartilhada): São páginas que vão ser utilizadas por mais de um controlador

- appsettings.json: é um arquivo que vai conter a configuração de recursos externos, Ex:
conexão com o Banco de Dados

- Cada método do Controlador é mapeado para uma ação.

- ViewData: É um dicionário no C#, ou seja, é uma coleção de pares chave e valor

- Return View(): O View é o que chamamos de methodBuilder. Método auxiliar que vai retornar pra
gente IActionResult

- IActionResult: É uma interface, que ele é um tipo genérico para todo resultado de uma ação

- Seeding Service: Popular a base de dados, serviço independente da migrations

- CSRF (Ataque): É quando alguém aproveita a sua sessão de autenticação e envia dados maliciosos
aproveitando a sua autenticação
