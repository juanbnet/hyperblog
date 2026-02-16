
objetivo=int(input('Digite un numero:'))
respuesta=0

while respuesta**2<objetivo:
    respuesta+=1


if respuesta**2==objetivo:
    print(f'La raiz cuadrada es {respuesta}')
else:
    print(f'no tiene raiz cuadrada exacta')
