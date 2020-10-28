
# API 1

## 1) Retornar a taxa de juros

* Nome da rota "/taxaJuros"
* Deve retornar o valor de 0.01 [HardCode value]

## Solution `InterestRate.sln`

A Solution é composta por dois projetos

1- `Soft.InterestRate.Api`
- Representa a camada de aplicação, responsável unicamente por efetuar a comunicação entre a apresentação e a domínio.

2 - `Soft.InterestRate.Domain`
- Representa a camada de domínio, responsável por fornecer o valor a ser utilizado.
- Como fica subtendida a possibilidade de modificação do valor, não é de responsabilidade do domínio saber o valor e sim unicamente retornar.

## Consumindo o Domínio

Dependências

1 - `IService<InterestRateEntity>` serviço que irá fornecer o valor a ser retornado pelo `Controller`

2 - `InterestRateEntity` entidade que conterá o valor a ser retornado pelo `Controller`

3 - Invertendo o controle. O controle da injeção de dependencias foi dado ao .net core. Como o valor é HardCode a entidade a ser injetada é um Singleton, pois não há risco de código concorrente.

```csharp
	#region Dependences

	services.AddScoped<IService<InterestRateEntity>, InterestRateService>();
	services.AddSingleton<InterestRateEntity>(r => new InterestRateEntity() { Value = 0.01M });

	#endregion
```

> **Observação:** Ficou entendido que o valor da taxa de juros deveria ficar em HardCode, por este motivo não criei uma variável de ambiente para pegar este valor. Normalmente não colocaria valores fixo em código para evitar uma futura compilação.


### Testes `Soft.InterestRate.Test`

Foram feitos testes de integração e unitários.

> **Observação:** O projeto de teste foi criado utilizando o xUnit. Para cada teste foi utilizada uma `Theory`, mas em um dos casos entendo que poderia ter sido utilizado um `Fact`.

### Teste de Integração

- Para execução foi utilizado o pacote `Microsoft.AspNetCore.Mvc.Testing` e `FluentAssertions`.

> **Observação** Foi executado somente um teste, visto que a API deve retornar um valor fixo no código. A API tem somente um Get, por este motivo achei desnecessário executar testes para erro 404 e não vi necessidade de testes para erro 500 visto que estes seriam detectados no teste unitário.

### Teste Unitário
- Para execução foi utilizado o pacote `Moq` e `FluentAssertions`.

> **Observação** Neste teste me dei ao luxo de modificar os valores a serem retornados. Como o valor da API era HardCode não há critérios sobre valores negativos. Por este motivo não há qualquer validação a nível de serviço logo coloquei nos testes valores negativos.
Num projeto, no futuro uma modificação proibindo valores negativos faria que alguns dos testes falhassem.
### Publicando a solution em um container Docker
- **gerando a imagem** No console digite o comando `docker build -t interest-rate .` e aguarde o término da execução. 
- **gerando um container** No console digite o comando `docker run -p 8200:80 -it interest-rate`
- **abrindo api no container** Abra o navegador de sua preferencia e digite na barra de endereços `http://localhost:8200`
> **observação** Será necessário ter o Docker instalado para este procedimento. Utilizei a porta 8200 somente para evitar conflito com outras portas no meu computador, mas você pode alterar com quiser.

