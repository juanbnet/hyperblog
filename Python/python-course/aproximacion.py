objetivo=int(input('Digite un número: '))
epsilon=0.01
paso=epsilon**2
respuesta=0.0

while abs(respuesta**2-objetivo)>=epsilon and respuesta<objetivo:
    print(f'abs(respuesta**2-objetivo): {abs(respuesta**2-objetivo)} , respuesta: {respuesta}')
    respuesta+=paso

if abs(respuesta**2-objetivo)>=epsilon:
    print(f'no hay respuesta exacta')
else:
    print(f'la raiz cuadrada es {respuesta}')


