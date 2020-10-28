
# API 1

## 1) Retornar a taxa de juros

* Nome da rota "/taxaJuros"
* Deve retornar o valor de 0.01 [HardCode value]

## Solution `InterestRate.sln`

A Solution é composta por dois projetos

1- `Soft.InterestRate.Api`
- Representa a camanda de aplicação, responsável unicamente por efetuar a comunicação entre a camada de apresentação e a camada de domínio.

2 - `Soft.InterestRate.Domain`
- Representa a camada de domínio, responsável por fornecer o valor a ser utilizado.
- Como fica subtendida a possibilidade de modificação do valor, não é de responsabilidade do domínio saber o valor e sim unicamente retornar.

## Consumindo o Domínio

Dependencias

1 - `IService<InterestRateEntity>` serviço que irá fornecer o valor a ser retornado pelo `Controller`

2 - `InterestRateEntity` entidade que conterá o valor a ser retornado pelo `Controller`

3 - Invertendo o controle. O controle da injeção de dependencias foi dado ao .net core. Como o valor é HardCode a entidade a ser injetada é um Singleton, pois não há risco de código concorrente.

```csharp
	#region Dependences

	services.AddScoped<IService<InterestRateEntity>, InterestRateService>();
	services.AddSingleton<InterestRateEntity>(r => new InterestRateEntity() { Value = 0.01M });

	#endregion
```

> **Observação:** Ficou entendido que o valor da taxa de juros deveria ficar em HardCode, por este motivo não criei uma variavel de ambiente para pegar este valor. Normalmente não colocaria valores fixo em código para evitar uma futura compilação.
