WebScrapingAEC

O objetivo deste projeto é desenvolver um serviço de Web Scraping capaz de extrair informações de uma página da web de forma automatizada e eficiente. Para isso, utilizamos a biblioteca Selenium para controlar um navegador Firefox e acessar a página desejada.

O processo de extração de informações é realizado pelo método Get, que recebe como parâmetro um objeto WordSearchList contendo uma lista de palavras-chave a serem pesquisadas. A partir da primeira página de resultados da busca, é feita a navegação para cada URL correspondente e, em seguida, é extraído o código HTML da página.

O código HTML é tratado utilizando expressões regulares (regex) e lógica de mapeamento de strings para extrair informações específicas de cada resultado de busca, como o título, a área, a descrição, o autor e a data de publicação. As informações extraídas são armazenadas em objetos do tipo PublicationSearchResultEntity e adicionadas a uma lista chamada virtualMatrixPublicationSearchResult.

Por fim, os resultados são percorridos e inseridos em um banco de dados fornecido através do construtor da classe (_repositoryData), utilizando o método InsertAsync. O método Get retorna uma variável booleana que indica se ocorreu algum erro durante a busca.

A estratégia adotada no código apresentado é eficiente e rápida, uma vez que a utilização da biblioteca Selenium permite a automatização da captura do HTML. Além disso, a utilização de expressões regulares e lógica de mapeamento de strings torna possível extrair informações precisas de forma estruturada a partir do código HTML capturado.

Em resumo, o serviço de Web Scraping desenvolvido neste projeto é uma solução eficiente e automatizada para a extração de informações de páginas web, que pode ser utilizada em diversas aplicações.

Tecnologias Utilizadas:

ORM - EF Core, abordagem codefirst com migrations.
.NET 7 com C#
WebDrive Selenium para Firefox
Npgsql para conexao com o BD PostGre
BD Postgre

Não optou-se por utilizar GitFlow pois é apenas um prototipo rapido e apenas uma pessoa esta trabalhando.

![image](https://user-images.githubusercontent.com/42627524/228366755-afeb2df0-d844-4cef-8bd6-888f3f57c882.png)


![image](https://user-images.githubusercontent.com/42627524/228367238-e9162e48-1bc7-4e2e-a4d7-ff5910275fc2.png)

