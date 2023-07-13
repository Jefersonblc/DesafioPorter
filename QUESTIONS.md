# Questões

1. Como você implementou a função que retorna a representação por extenso do número no desafio 1? Quais foram os principais desafios encontrados?
R: Eu implementei como uma Extension Method do C# e fiz dividindo o número de todas as casas das dezenas, centenas, milhar, milhão, bilhão e trilhão. Quanto é feita cada divisão a função faz de forma recursiva até chegar nos dígitos. 
O maior problema foi mapear os dígitos e ligar os números corretamente

2. Como você lidou com a performance na implementação do desafio 2, considerando que o array pode ter até 1 milhão de números?
R: A forma rápida e fácil não seria de grande problema mesmo com 1 milhão de números, porém consegui otimizar a função somando mais dígitos por loop. 

3. Como você lidou com os possíveis erros de entrada na implementação do desafio 3, como uma divisão por zero ou uma expressão inválida?
R: Foi validada a entrada por um regex, para impedir qualquer valor não numérico, que não seja uma operação matemática ou parênteses. 
Também a função checa durante a execução se tem algum parênteses desbalanceado ou se ocorre alguma divisão por zero na hora de realizar as operações.

4. Como você implementou a função que remove objetos repetidos na implementação do desafio 4? Quais foram os principais desafios
encontrados?
R: Eu utilizei uma HashSet para não permitir adicionar objetos iguais. Como eu fiz utilizando uma API, quando os dados são convertidos do JSON para a lista eles vêm com HashCodes diferentes, mesmo que o JSON seja o mesmo. 
Então tive que implementar um IEqualityComparer para serializar o objeto e depois gerar o HashCode
