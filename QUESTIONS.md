# Quest�es

1. Como voc� implementou a fun��o que retorna a representa��o por extenso do n�mero no desafio 1? Quais foram os principais desafios encontrados?
R: Eu implementei como uma Extension Method do C# e fiz dividindo o n�mero de todas as casas das dezenas, centenas, milhar, milh�o, bilh�o e trilh�o. Quanto � feita cada divis�o a fun��o faz de forma recursiva at� chegar nos d�gitos. 
O maior problema foi mapear os d�gitos e ligar os n�meros corretamente

2. Como voc� lidou com a performance na implementa��o do desafio 2, considerando que o array pode ter at� 1 milh�o de n�meros?
R: A forma r�pida e f�cil n�o seria de grande problema mesmo com 1 milh�o de n�meros, por�m consegui otimizar a fun��o somando mais d�gitos por loop. 

3. Como voc� lidou com os poss�veis erros de entrada na implementa��o do desafio 3, como uma divis�o por zero ou uma express�o inv�lida?
R: Foi validada a entrada por um regex, para impedir qualquer valor n�o num�rico, que n�o seja uma opera��o matem�tica ou par�nteses. 
Tamb�m a fun��o checa durante a execu��o se tem algum par�nteses desbalanceado ou se ocorre alguma divis�o por zero na hora de realizar as opera��es.

4. Como voc� implementou a fun��o que remove objetos repetidos na implementa��o do desafio 4? Quais foram os principais desafios
encontrados?
R: Eu utilizei uma HashSet para n�o permitir adicionar objetos iguais. Como eu fiz utilizando uma API, quando os dados s�o convertidos do JSON para a lista eles v�m com HashCodes diferentes, mesmo que o JSON seja o mesmo. 
Ent�o tive que implementar um IEqualityComparer para serializar o objeto e depois gerar o HashCode
