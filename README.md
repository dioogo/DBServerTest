# DBServerTest

O sistema foi desenvolvido utilizando Microsoft Visual Studio Community 2015, .NET Framework 4.5.2 e IIS 6.2.
Para a injeção de dependência foi utililizado a biblioteca Unity. Já para os mocks dos testes unitários foi usado NSubstitute. A webapi foi construída em cima das bibliotecas default do .NET.

Para acessar o site basta entrar nesse link: http://localhost/DBServerTest/ 

A home do site é a página de votação. Basta escolher uma opção de restaurante e votar. Após votar, você verá o resultado até o momento e será impedido de votar novamente pelos próximos dois minutos (simulando o fato de tu não poder votar mais nesse dia). Se tentar acessar o site antes dos dois minutos terminarem, você verá o resultado da votação até o momento.

Os dados são fakes, não foi implementado o banco de dados. Então haverá inconsistência entre a contagem do seu voto e o resultado parcial, caso você recarregue a página.