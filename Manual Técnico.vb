							MANUAL TÉCNICO
												
	A continuación presentamos el manual técnico que contiene los pseudocódigos utilizados para este proyecto así como una breve
descripción de cada uno para saber cual es su funcionamiento y labor dentro del proyecto:


(MENÚ PRINCIPAL)

	Para empezar tenemos el siguiente pseudocodigo el cual nos muestra el Menú Principal del juego donde se podrá ir a jugar, 
comprar cosas en la tienda, generar el tablero, ver el inventario y salir del juego, del mismo modo controla los datos escritos 
por el jugador y en caso ingrese un número incorrecto se le notificará y se le pedirá que ingrese otro número.

	Var nombreDelJugador
	Var primeraPartida = false
	Var opcion = 0
	Var oro = 0

	Escribir "Escribe tu Nombre"
	Leer nombreDelJugador
	
	Escribir "---------------"
	Escribir "Bienvenido" 
	Escribir nombreDelJugador
	Escribir "---------------"
	
	mientras (opcion != 5) hacer
		Escribir "MENÚ PRINCIPAL"
		Escribir "Escriba el Número de una de las Siguientes Opciones:"
		Escribir "    1. Iniciar Partida"
		Escribir "    2. Tienda"
		Escribir "    3. Generación de Tablero"
		Escribir "    4. Inventario"
		Escribir "    5. Salir"
		Leer opcion
		
		Si (opcion == 1) entonces
			Var decision = 0
			
			Si (!primeraPartida) entonces
				oro = 500
				Escribir "INICIAR PARTIDA"
				Escribir "------------------------------------------------------------------"
				Escribir "- Para empezar se te obsequiará 500 de Oro."
				Escribir "- Recuerde que una vez Inicie un Nuevo Juego no podra regresar al"
				Escribir "  Menú Principal hasta que este en batalla."
				Escribir "- Antes de Iniciar el Juego compra 2 personajesen la Tienda, para"
				Escribir "  que te ayuden en la Batalla."
				Escribir "- Luego compra algunos objetos que te servirán durante la batalla."
				Escribir "------------------------------------------------------------------"
				
				mientras (decision != 2) hacer
					Escribir "¿Quiere iniciar un Nuevo Juego?, Escribe el Número de tu Respuesta"
					Escribir "    1. Si"
					Escribir "    2. No"
					Leer decision

					Si (decision == 1) entonces
						Llamar irALaTienda_1()
						Llamar organizarEquipo()
						Llamar seleccionarTablero()
						Llamar nuevaBatalla.iniciarJuego()
						Llamar primeraPartida = true
						decision = 2
					sino Si (decision != 2) entonces
						Llamar imprimirError()
					finsi
					
				finmientras
			sino
				Escribir "INICIAR PARTIDA"
				Escribir "-----------------------------------------------------------------"
				Escribir "- Recuerde que una vez Inicie un Nuevo Juego no podra regresar al"
				Escribir "  Menú Principal hasta que este en batalla."
				Escribir "-----------------------------------------------------------------"
				Llamar irALaTienda_2()
				Llamar organizarEquipo()
				Llamar seleccionarTablero()
				Llamar nuevaBatalla.iniciarJuego()
				decision = 2
			finsi
			
		sino Si (opcion == 2) entonces
			Llamar irALaTienda_3()
		sino Si (opcion == 3) entonces
			Llamar generarTablero()
		sino Si (opcion == 4) entonces
			Llamar verInventario()
		sino Si (opcion == 5) entonces
			Escribir "-----------------"
			Escribir "Gracias por Jugar"
			Escribir "-----------------"
		sino
			Llamar imprimirError()
		finsi
		
	finmientras
---------------------------------------------------------------------------------------------------------------------------------


(TIENDA NO.1)

	Para la creación de la tienda elaboramos diferentes ideas para cubrir las necesidades en cada apartado donde era solicitado 
siendo en total 3 tipos de tiendas las que se usaron para lograr cumplir con lo que se nos pedía. El siguiente pseudocodigo es de
la primera tienda que es utilizada cuando el jugar efecuta su primera partida, en la cual hay que permitirle comprar 2 personajes
y despues permitirle comprar objetos hasta que el jugador desee o hasta que ya no tenga oro.

	Var numeroDePersonajes
	Var opcion_1 = 0
	Var opcion_2 = 0
	
    Escribir "TIENDA (PERSONAJES)"
	
	mientras (numeroDePersonajes != 2) hacer
	
		Escribir "Oro: " + oro);
		Escribir "Escriba el Número del Personaje que desea Comprar:"
		Escribir "    1. Caballero"
		Escribir "    2. Arquero"
		Escribir "    3. Mago"
		Escribir "    4. Gigante"
		Escribir "    5. Dragón"
		Leer opcion_1

		Si (opcion_1 > 0 && opcion_1 < 6) entonces
			int oroGastado = oro
			Llamar comprarPersonajes()

			Si (oroGastado != oro) entonces
				numeroDePersonajes++
			finsi
		sino
			Llamar imprimirError()
		finsi
		
	finmientras
	
	Escribir "TIENDA (OBJETOS)"
	
	mientras (opcion_2 != 4) hacer
	
		Escribir "Oro: "
		Escribir oro
		Escribir "Escriba el Número del Objeto que desea Comprar ó pulse 4 para Continuar"
		Escribir "    1. Semilla de la Vida"
		Escribir "    2. Elixir Verde"
		Escribir "    3. Capa de Movilidad"
		Escribir "    4. Continuar a Selección de Personajes"
		Leer opcion_2
		
		Si (opcion_2 > 0 && opcion_2 < 4) entonces
			Llamar comprarObjetos()
		sino Si (opcion_2 == 4) entonces
			Regresar al Menú Principal
		sino
			Llamar imprimirError()
		finsi
		
	finmientras	
---------------------------------------------------------------------------------------------------------------------------------


(TIENDA NO.2)

	El siguiente pseudocódigo es utilizada cuando el usuario ya jugó por primera vez el juego por lo tanto para esta ocasión se 
le presentará la tienda para que pueda comprar personajes y objetos siempre y cuando tenga dinero para comprarlos de lo contrario
no se ejecuará la compra y por último se le dará una opción para que pueda seguir con los preparativos de la batalla.

	Var paso = false
	Var opcion_1 = 0
	Var opcion_2 = 0
	
	Escribir "TIENDA"
		
	mientras (!paso) hacer
		Escribir "Oro: "
		Escribir oro
		Escribir "Escriba el Número de una de las Siguientes Opciones:"
		Escribir "    1. Comprar Objetos"
		Escribir "    2. Comprar Personajes"
		Escribir "    3. Continuar a Selección de Personajes"
		Lerr opcion_1
		
		Si (opcion_1 == 1) entonces
			
			mientras (opcion_2 != 4) hacer
				Escribir "Escriba el Número del Objeto que desea Comprar:"
				Escribir "    1. Semilla de la Vida"
				Escribir "    2. Elixir Verde"
				Escribir "    3. Capa de Movilidad"
				Escribir "    4. Regresar al Menú de la Tienda"
				Leer opcion_2

				Si (opcion_2 == 1 || opcion_2 == 2 || opcion_2 == 3) entonces
					Llamar comprarObjetos()
					opcion_2 = 4
				sino Si (opcion_2 != 4) entonces
					imprimirError()
				finsi
				
			finmientras
			
		sino Si (opcion_1 == 2) entonces
			Var opcion_2 = 0
			
			mientras (opcion_2 != 6) hacer
				Escribir "Escriba el Número del Personaje que desea Comprar:"
				Escribir "    1. Caballero"
				Escribir "    2. Arquero"
				Escribir "    3. Mago"
				Escribir "    4. Gigante"
				Escribir "    5. Dragón"
				Escribir "    6. Regresar al Menú de la Tienda"
				Leer opcion_2

				Si (opcion_2 == 1 || opcion_2 == 2 || opcion_2 == 3 || opcion_2 == 4 || opcion_2 == 5) entonces
					Llamar comprarPersonajes()
					opcion_2 = 6
				sino Si (opcion_2 != 6) entonces
					imprimirError()
				finsi
				
			finmientras
			
		sino Si (opcion_1 == 3) entonces
			paso = true
		sino
			Llamar imprimirError()
		finsi
		
	finmientras	
---------------------------------------------------------------------------------------------------------------------------------


(TIENDA NO.3)

	El siguiente algoritmo sirve para la tercera sección de la tienda ya que esta es la que aparece en el menú principal es la 
única donde se podrá comprar mejoras para los personajes, y de igual manera se podrá comprar personajes y objetos.

	Var equipoJugador[5]
	Var opcion_1 = 0
	Var oro
	
	mientras (opcion_1 != 4) hacer
	
		Escribir "TIENDA"
		Escribir "Oro: "
		Escribir oro
		Escribir "Escriba el Número de una de las Siguientes Opciones:"
		Escribir "    1. Comprar Objetos"
		Escribir "    2. Comprar Personajes"
		Escribir "    3. Comprar Mejoras"
		Escribir "    4. Regresar al Menú Principal"
		Leer opcion_1

		Si (opcion_1 == 1) entonces
		
			Var opcion_2 = 0
			
			mientras (opcion_2 != 4) hacer
			
				Escribir "Escriba el Número del Objeto que desea Comprar:"
				Escribir "    1. Semilla de la Vida"
				Escribir "    2. Elixir Verde"
				Escribir "    3. Capa de Movilidad"
				Escribir "    4. Regresar al Menú de la Tienda"
				Leer opcion_2

				Si (opcion_2 == 1 || opcion_2 == 2 || opcion_2 == 3) entonces
					Llamar comprarObjetos()
					opcion_1 = 4
					opcion_2 = 4
				sino Si (opcion_2 != 4) entonces
					Llamar imprimirError()
				finsi
				
			finmientras
			
		sino Si (opcion_1 == 2) entonces
			int opcion_2 = 0
			
			mientras (opcion_2 != 6) hacer
			
				Escribir "Escriba el Número del Personaje que desea Comprar:"
				Escribir "    1. Caballero"
				Escribir "    2. Arquero"
				Escribir "    3. Mago"
				Escribir "    4. Gigante"
				Escribir "    5. Dragón"
				Escribir "    6. Regresar al Menú de la Tienda"
				Leer opcion_2

				Si (opcion_2 == 1 || opcion_2 == 2 || opcion_2 == 3 || opcion_2 == 4 || opcion_2 == 5) entonces
					Llamar comprarPersonajes()
					opcion_1 = 4
					opcion_2 = 6
				sino Si (opcion_2 != 6) entonces
					Llamar imprimirError()
				finsi
				
			finmientras
			
		sino Si (opcion_1 == 3) entonces
			
			Si (equipoJugador[0] != null) entonces
				Var opcion_2 = 0

				mientras (opcion_2 != 4) hacer
				
					Escribir "Escriba el Número de la Mejora que desea Comprar:"
					Escribir "    1. Vida"
					Escribir "    2. Daño"
					Escribir "    3. Movilidad"
					Escribir "    4. Regresar al Menú de la Tienda"
					Leer opcion_2

					Si (opcion_2 == 1 || opcion_2 == 2 || opcion_2 == 3) entonces
						Var recibirInformacion = comprarMejoras()                       
						oro = recibirInformacion[0]
						
						Si (recibirInformacion[1] == 0) entonces
							opcion_1 = 4
							opcion_2 = 4
						finsi
						
					sino Si (opcion_2 != 4) entonces
						Llamar imprimirError()
					finsi
					
				finmientras	
				
			sino
				Escribir "No tienes Personajes en tu Equipo para Mejorar"
			finsi
			
		sino Si (opcion_1 != 4) entonces
			Llamar imprimirError()
		finsi
		
	finmientras
---------------------------------------------------------------------------------------------------------------------------------


(Generar Tableros)

	Este pseudocodigo es utilizado para realizar la creación de un nuevo tablero de juego para el cual se le pediran la fila y
columna al jugador revisando que estos sean mayor que 8, y posteriormente se le pedira al jugador los porcentajes de generacion
de las casillas como son el agua, los arboles y la lava se verifica los datos ingresados y por último se le pide al jugador que 
le ponga un nombre al nuevo mapa.

	Var generacionDelArbol = 0
	Var generacionDelAgua = 0
	Var generacionDeLaLava = 0
	Var nuevoTablero[x][y]
	Var paso
	Var salir
	Var x = 0
	Var y = 0

	Escribir "GENERADOR DE TABLEROS"
	
	mientras (!paso) hacer
		Escribir "Escriba el Número de Filas"
		Leer x 
		x += 1
		Escribir "Escriba el Número de Columnas"
		Leer y
		y += 1
		
		Si (x >= 9 && y >= 9) entonces
			paso = true
		sino
			Escribir "--------------------------------------------------------"
			Escribir "El Número de Filas y Columnas debe ser mayor o igual a 8"
			Escribir "--------------------------------------------------------"
		finsi
		
	finmientras
	
	Desde i = 0; hasta x; 1
		Desde j = 0; hasta y; 1
			nuevoTablero[i][j] = " "
		findesde
	findesde
	
	Desde i = 1; hasta y; 1
		nuevoTablero[0][i] = i
	findesde
	
	Desde i = 1; hasta x; 1
		nuevoTablero[i][0] = i
	findesde
	
	nuevoTablero[0][0] = "0"
	
	Desde i = 0; hasta x; 1	
		Desde j = 0; hasta y; 1
			Escribir nuevoTablero[i][j]
		findesde		
	findesde
	
	mientras (!salir) entonces
		Escribir "Escriba los siguientes Porcentajes entre el Rango de 1 a 100"
		Escribir "Escriba el % de Generación que tendrá el Árbol"
		Leer generacionDelArbol       
		Escribir "Escriba el % de Generación que tendrá el Agua"
		Leer generacionDelAgua
		Escribir "Escriba el % de Generación que tendrá la Lava"
		Leer generacionDeLaLava

		Si (generacionDelAgua > 0 && generacionDelAgua < 101 && generacionDeLaLava > 0 && generacionDeLaLava < 101) entonces
			salir = true;
		sino
			Escribir "-------------------------------------------------------"
			Escribir "Se excedio el Rango de Generación, Intentelo Nuevamente"
			Escribir "-------------------------------------------------------"
		finsi
		
	finmientras
	
	Var nombreDelTablero
	
	Escribir "Escriba el Nombre del Nuevo Tablero de Juego:"
	Leer nombreDelTablero
	personalizado
	Escribir "------------------------------------------------------------------------------"
	Escribir "Tablero Generado Exitosamente, puedes Jugarlo en la sección de Iniciar Partida"
	Escribir "------------------------------------------------------------------------------"	
---------------------------------------------------------------------------------------------------------------------------------


(Ver Inventario)

	Este pseudocodigo es utilizado cuando el jugador quiera revisar su inventario de personajes y de objetos y si tiene objetos 
en su inventario se le de la opción de poder vender algunos de los objetos que ya no sean requeridos por el jugador y por el cual
se le pagará el precio del producto en su totalidad.

	Var contador_1 = 0
	Var contador_2 = 0
	Var inventarioDeObjetosVacio = true
	Var equipoJugador[5]
	
	Escribir "BIENVENIDO AL INVENTARIO"
	Escribir "Equipo:"
	
	Desde cont = 0; hasta 10; 1		
		Si (equipoJugador[cont] != null) entonces
			Escribir "Nombre: "
			Escribir Nombre del Jugador
			Escribir "Daño: "
			Escribir Número de Daño
			Escribir "Vida: "
			Escribir Número de Vida
			contador_1++
		finsi
		
	findesde
	
	Si (contador_1 == 0) entonces
		Escribir "No tienes ningún Personaje dentro de tu Equipo"
	finsi
	
	Escribir "Objetos:"
	
	Desde cont = 0; hasta 10; 1	
		Si (objetosJugador[i] != 0) entonces
			Escribir "Nombre: "
			Escribir Nombre del Objeto
			Escribir "Habilidad: "
			Escribir Nombre de la Habilidad
			contador_2++
			inventarioDeObjetosVacio = false
		finsi
		
	findesde
	
	Si (contador_2 == 0) entonces
		Escribir "No tienes ningún Objeto para Utilizar"
	finsi
		
	Si (!inventarioDeObjetosVacio) entonces
		Var opcion = 0
		
		mientras (opcion != 2) hacer
			Escribir "Desea Vender un Objeto, Escriba el Número de su Decisión:"
			Escribir "    1. Si, Deseo Vender"
			Escribir "    2. No, Regresar al Menú Principal"
			Leer opcion

			Si (opcion == 1) entonces
				Var opcion_2 = 0
				
				mientras (opcion_2 != 11) hacer
					Escribir "Escriba el Número de Objeto que desea Vender:"

					Desde i = 0; hasta 10; 1
						Si (objetosJugador[i] != null) entonces
							Escribir "Nombre: Poner Nombre del Jugador
						sino
							Escribir "Nombre:  ---------"
						finsi
						
					findesde
					
					Escribir "    11. Regresar al Menú de Objetos"
					Leer opcion_2

					Si (opcion_2 > 0 && opcion_2 < 11) entonces   
					
						Si (objetosJugador[opcion_2 - 1] != null) entonces
							Llamar objetosJugador[opcion_2 - 1].getPrecio()
							objetosJugador[opcion_2 - 1] = null

							Desde i = opcion_2 - 1; hasta 10
								Si (i != 9) Entonces
									objetosJugador[i] = objetosJugador[i + 1]
								sino
									objetosJugador[i] = null
								finsi
								
							findesde
							
							oro += precio
							opcion = 2
							opcion_2 = 11
						sino
							Escribir "------------------------------------"
							Escribir "No hay Ningún Objeto en esta casilla"
							Escribir "------------------------------------"
						finsi
						
					sino Si (opcion_2 == 11) entonces
						opcion = 2
					sino
						Llamar imprimirError()
					finsi
					
				finmientras
				
			sino Si (opcion != 2) entonces
				Llamar imprimirError()
			finsi			
		finsi
	finsi
---------------------------------------------------------------------------------------------------------------------------------


(ORGANIZAR EQUIPO)

	Este pseudocodigo es utilizado para seleccionar los 2 personajes que serán utilizados en batalla se le despliegará la lista 
al jugador y este escribirá el número del personaje que desea seleccionar, si la posición que escoge no esta ocupada por algún
personaje se le deberá de informar al jugador y pedirle que vuelva a seleccionar nuevamente, también se controlará que el jugador
no seleccione al mismo personaje más de una vez.

	Var opcion = 0
	Var contador = 0
	Var numeroDeCompra = 0
	Var equipoJugador[5]
	Var duoJugador[2]
	   
	mientras (contador != 2) hacer
		Escribir "SELECCION DE (PERSONAJES)"
		Escribir "Selecciona dos Personajes de tu Equipo para la Batalla, Escribe el Número del Personaje"
		
		Desde i = 0; hasta 5; 1       
			Si (equipoJugador[i] != null) entonces
				Escribir nombreDelJugador
			sino
				Escribir "----------"
			finsi
			
		findesde
		
		Leer opcion
		
		Si (opcion > 0 && opcion < 6) entonces  
		
			Si (equipoJugador[opcion - 1] != null) entonces
			
				Si (numeroDeCompra == 0) entonces
					duoJugador[contador] = equipoJugador[opcion - 1]
					Escribir "---------------------------------------------"
					Escribir "Su personaje fue seleccionado para la Batalla"
					Escribir "---------------------------------------------"
					numeroDeCompra = opcion
					contador++
				sino Si (opcion == numeroDeCompra) entonces
					Escribir "----------------------------------------------"
					Escribir "Personaje ya Seleccionado, Intentalo Nuevamente"
					Escribir "----------------------------------------------"
				sino
					duoJugador[contador] = equipoJugador[opcion - 1]
					Escribir "------------------------------------------"
					Escribir nombreDelJugador
					Escribir " fue seleccionado para la Batalla"
					Escribir "------------------------------------------"
					contador++
				finsi
				
			sino
				Escribir "---------------------------------------"
				Escribir "No hay Ningún Personaje en esta Casilla"
				Escribir "---------------------------------------"
			finsi
			
		sino
			Llamar imprimirError()
		finsi
		
	finmientras
---------------------------------------------------------------------------------------------------------------------------------


(SELECCIONAR TABLERO)

	Este pseudocodigo es utilizado cuando el jugador tenga que seleccionar un tablero para jugar, se le presentarán 2 opciones la
primera es el tablero predeterminado y la segunda el tablero que el jugador creo, si el jugador no a creado ningun tablero solo 
se le permitirá seleccionar el tablero predeterminado y se le presentará una tercera opción para que cree el tablero nuevo.

	Var aJugar[x][y]
	Var tieneSegundoTablero = false
	Var seleccionoTablero = false
	Var nombreDelTablero
	Var opcion
	
	mientras (!seleccionoTablero) hacer
		Escribir "SELECCIÓN DE TABLERO"
		Escribir "Escribe el Número de Tablero que deseas Jugar ó pulsa 3 para generar uno Nuevo"
		Escribir "    1. Predeterminado"
		
		Si (personalizado == null) entonces
			Escribir "    2. --------"
		sino
			Escribir "    2. "
			Escribir nombreDelTablero
			tieneSegundoTablero = true
		finsi
		
		Escribir "    3. Generar un Nuevo Mapa"
		Leer opcion
	
		Si (opcion == 1) entonces
			Escribir "-----------------------------------"
			Escribir "Tablero Predeterminado Seleccionado"
			Escribir "-----------------------------------"
			aJugar = predeterminado
			seleccionoTablero = true
		sino Si (opcion == 2) entonces            
			Si (tieneSegundoTablero) entonces
				Escribir "------------------------"
				Escribir "Tablero"
				Escribir Escribir nombreDelTablero
				Escribir "------------------------"
				aJugar = personalizado;
				seleccionoTablero = true;
			sino
				Escribir "------------------------------"
				Escribir "No has Generado ningún Tablero"
				Escribir "------------------------------"
			finsi
			
		sino Si (opcion == 3) entonces
			Llamar generarTablero()
		sino
			Llamar imprimirError()
		finsi
		
	finmientras	
---------------------------------------------------------------------------------------------------------------------------------


(IMPRIMIR ERROR)

	Este pseudocodigo se implemento por las muchas vecez que habia que mostrar el mismo mensaje de error durante la ejecución del 
programa entonces para ahorranos un poco de espacio y para que fuera más agradable a la vista se decidio separar esta función que
lo único que hace es mostrar el mensaje de error.

	Escribir "---------------------------------------"
    Escribir "Número Incorrecto, Intentelo Nuevamente"
    Escribir "---------------------------------------"
	
---------------------------------------------------------------------------------------------------------------------------------


(COMPRAR OBJETOS)

	El siguiente pseudocódigo es utilizado cuando el jugador ya selecciono el objeto que desea comprar y se verifica si tiene oro
o no y tiene se ejecuta la compra y se agrega al inventario de lo contrario no se ejecuta la compra y se manda un mensaje.

	Var nuevoObjeto = null
        
	Si (numeroDeCompra == 1) entonces
		nuevoObjeto = new SemillaDeLaVida()
	sino Si (numeroDeCompra == 2) entonces
		nuevoObjeto = new ElixirVerde()
	sino Si (numeroDeCompra == 3) entonces
		nuevoObjeto = new CapaDeMovilidad()
	finsi
	
	Var tieneOro = Llamar verificarOro(oro)
	
	if (tieneOro) {
		Var seRealizoLaCompra = revisar si se Realizo la Compra
		
		Si (seRealizoLaCompra) entonces
			Escribir "---------------------------------------------------------------"
			Escribir nombreDelObjeto
			Escribir "Se agrego a tu Inventario, Realizo la Compra"
			Escribir "---------------------------------------------------------------"               
			oro -= gasto;
		sino
			Escribir "-----------------------------------------------------------"
			Escribir "No tienes Espacio en tu Inventario, No se realizo la Compra"
			Escribir "-----------------------------------------------------------"
		finsi
		
	finsi
---------------------------------------------------------------------------------------------------------------------------------


(COMPRAR PERSONAJES)

	El siguiente pseudocódigo es utilizado cuando el jugador ya realizo la selección del personaje que desea comprar y ahora en
este pedazo de codigo toca verificar el oro y mandar a llamar al subprograma que verifica que no sea un personaje repetido.

	Var nuevoPersonaje = null     
	Var tieneOro = verificarOro(oro)
        
	Si (tieneOro) entonces
	
		Si (numeroDeCompra == 1) entonces
			nuevoPersonaje = new Caballero()
		sino Si (numeroDeCompra == 2) entonces
			nuevoPersonaje = new Arquero()
		sino Si (numeroDeCompra == 3) entonces
			nuevoPersonaje = new Mago()
		sino Si (numeroDeCompra == 4) entonces
			nuevoPersonaje = new Gigante()
		sino Si (numeroDeCompra == 5) entonces
			nuevoPersonaje = new Dragón()
		finsi
		
		Var seRealizoLaCompra = Llamar agregarAlEquipo(nuevoPersonaje,equipoJugador)
		
		if (seRealizoLaCompra) entonces
			Escribir "-----------------------------------------"
			Escribir nuevoPersonaje.getNombre() 
			Escribir "se unió a tu Equipo, se Realizo la Compra"
			Escribir "-----------------------------------------"
			oro -= 200
		sino
			Si (copias == 0) entonces
				Escribir "-------------------------------------------------------"
				Escribir "No tienes Espacio en tu Equipo, No se realizo la Compra"
				Escribir "-------------------------------------------------------"
			sino
				Escribir "----------------------------------------------------------------"
				Escribir "Ya tienes a este Personaje en tu Equipo, No se realizo la Compra"
				Escribir "----------------------------------------------------------------"
				copias = 0;
			finsi
			
		finsi
		
	finsi
---------------------------------------------------------------------------------------------------------------------------------


(COMPRAR MEJORAS)

	Este pseudocódigo es utilizado para comprar las mejoras para los personajes y las verificaciones que hace es mandar a revisar
el oro y verificar que el jugador tenga personajes a quién darselo.

	Var flujoDelPrograma
	Var nuevaMejora = new Mejora()      
	
	Si (numeroDeCompra == 1) entonces
		nuevaMejora = new Vida()
	sino Si (numeroDeCompra == 2) entonces
		nuevaMejora = new Daño()
	sino Si (numeroDeCompra == 3) entonces
		nuevaMejora = new Movilidad()
	finsi
	
	Var tieneOro = Llamar verificarOro(oro,nuevaMejora.getPrecio(),3)
	
	Si (tieneOro) entonces      
		paso = false
		
		mientras (!paso) hacer
			Escribir "Escriba el Número del Personaje que Desea Mejorar:"
			
			Desde cont = 0; hasta 5; 1	
				Si (equipoJugador[i] == null) entonces
					Escribir "--------"
				sino
					Escribir equipoJugador[i].getNombre()
				finsi
				
			findesde
			
			Escribir "    6. Regresar al Menú de las Mejoras"
			Leer opcion

			Si (opcion > 0 && opcion < 7) entonces
			
				Si (opcion != 6) entonces
				
					Si (equipoJugador[opcion - 1] != null) entonces  
					
						Si (numeroDeCompra == 1) entonces
							equipoJugador[opcion - 1].setVida()
							paso = true
							oro -= nuevaMejora.getPrecio()
						sino Si (numeroDeCompra == 2) {
							equipoJugador[opcion - 1].setDaño()
							paso = true
							oro -= nuevaMejora.getPrecio()
						sino
							equipoJugador[opcion - 1].setMovilidad()
							paso = true
							oro -= nuevaMejora.getPrecio()
						finsi
						
						flujoDelPrograma[0] = oro
						Escribir "--------------------"
						Escribir "Se Realizo la Mejora"
						Escribir "--------------------"
					sino
						Escribir "----------------------------------------------------------------"
						Escribir "No hay Ningún Personaje en esta Casilla, No se Realizo la Mejora"
						Escribir "----------------------------------------------------------------"
					finsi
					
				sino
					flujoDelPrograma[0] = oro
					flujoDelPrograma[1] = 1
					paso = true
				finsi
				
			sino
				Escribir "---------------------------------------"
				Escribir "Número Incorrecto, Intentelo Nuevamente"
				Escribir "---------------------------------------"
			finsi
			
		finmientras
		
	finsi
---------------------------------------------------------------------------------------------------------------------------------


(VERIFICAR ORO)

	Este pseudocódigo es utilizado para verificar que el jugador pueda comprar el objeto, personaje o mejora segun haya sido la 
selección del usuario, si tiene el dinero regresará un verdadero de lo contrario retornará un falso.

	Var tieneOro = false
    Var contenido = "Mejoras"
        
	Si (oro >= oroMinimoRequerido) entonces
		tieneOro = true;
	sino
		if (indice == 1) {
			contenido = "Objetos"
		sino Si (indice == 2) entonces
			contenido = "Personajes"
		finsi
		
		Escribir "-------------------------------------"
		Escribir "No tienes Oro suficiente para Comprar"
		Escribir contenido
		Escribir "-------------------------------------"
	finsi
	
	retornar tieneOro
---------------------------------------------------------------------------------------------------------------------------------


(AGREGAR PERSONAJE)

	Este pseudocódigo nos va servir para agregar al equipo del usuario un nuevo personaje despúes de pasar los controles los 
respectivos controles de seguridad en los apartados anteriores, y este subprograma va buscar un espacio dentro del equipo
para poder agregar al nuevo jugador en caso no pudiera se le notificará al usuario para que sepa que ya tiene a todo el equipo
completo. Por ultimo retornará un valor con el cual sabremos si se realizo el movimiento o no.

	Var contador = 0
    Var compra = true
        
	Desde cont = 0; hasta 5; 1   
		Si (equipoJugador[i] == null) entonces
		
			Desde cont = 0; hasta 5; 1
				String aComparar = "-------"
				
				Si (equipoJugador[j] != null) entonces
					aComparar = equipoJugador[j].getNombre()
				finsi
				
				Si (aComparar == nuevoPersonaje.getNombre()) entonces
					copias++
				finsi
				
			findesde
			
			if (copias == 0) entonces
				equipoJugador[i] = nuevoPersonaje
				contador++
			finsi
			
		finsi
		
	findesde
	
	Si (contador == 0) entonces
		compra = false
	finsi
	
	retornar compra
---------------------------------------------------------------------------------------------------------------------------------


(GENERAR TABLERO)

	Este pseudocódigo es utilizado para poder agregar las diferentes casillas dentro del tablero en un orden alzar con el 
objetivo de hacer que todos los mapas sean diferentes.

	Var arbol = generacionDelArbol / 100
	Var agua = generacionDelAgua / 100
	Var lava = generacionDeLaLava / 100
	Var ponerArboles = false
	Var	ponerAgua = false
	Var ponerLava = false
	
	Desde cont = 0; hasta 3; 1
		Tirar un random
		
		Si (i == 0) entonces
			ponerArboles = random <= arbol
		sino Si (i == 1) entonces
			ponerAgua = random <= agua
		sino
			ponerLava = random <= lava
		finsi
		
	findesde
	
	Si (ponerAgua) entonces
		Tirar random para Número de Rios
		Tirar random para Casillas
		
		Si (numeroDeCasillas <= 0.50) entonces
			casillas = 3
		sino
			casillas = 4
		finsi
		
		mientras (contador <= numeroDeRios) hacer
			
			Si (contador == 0) entonces
				Var puedeSalir = false
				
				mientras (!puedeSalir) hacer
					Tirar random para la Columna

					Si (tablero[1][columna] == " ") entonces

						Desde cont = 0; hasta casillas; 1
							tablero[i][columna] = "a"
						findesde
						
						contador++;
						puedeSalir = true
					finsi
					
				finmientras
				
			sino Si (contador == 2) entonces    
				boolean puedeSalir = false
				
				mientras (!puedeSalir) hacer
					Tirar random para la Fila

					Si (tablero[x - 1][columna] == " " && tablero[x - 2][columna] == " " && tablero[x - 3][columna] == " " && tablero[x - 4][columna] == " ") entonces

						Desde cont = 0; hasta casillas; 1
							tablero[x - i][columna] = "a"
						findesde
						
						contador++
						puedeSalir = true
					finsi
					
				finmientras
				
			sino Si (contador == 1) entonces
				Var puedeSalir = false
				
				mientras (!puedeSalir) hacer
					Tirar random para la Fila

					Si (tablero[fila][1] == " " && tablero[fila][2] == " " && tablero[fila][3] == " " && tablero[fila][4] == " ") entonces

						Desde cont = 1; hasta casillas; 1
							tablero[fila][i] = "a"
						findesde
						
						contador++
						puedeSalir = true
					finsi
					
				finmientras
				
			finsi
			
		finmientras
		
	finsi    
	
	Si (ponerArboles) entonces
		Tirar random para colocar Arboles
		
		mientras (contador < numeroDeArboles) hacer
			Tirar random para la Fila
			Tirar random para la Columna
			
			Si (tablero[fila][columna] == " ") entonces
				tablero[fila][columna] = "A"
				arboles[contador].setFila(fila)
				arboles[contador].setColumna(columna)
				contador++
			finsi
			
		finmientras
		
	finsi

	Si (ponerLava) entonces
		Tirar random para el Número de Lava
		
		mientras (contador <= numeroDeLava) hacer
			Tirar random para la Fila
			Tirar random para la Columna
			
			Si (tablero[fila][columna] == " ") entonces
				tablero[fila][columna] = "L"
				contador++
			finsi
			
		finmientras
		
	finsi
--------------------------------------------------------------------------------------------------------------------------------


(INICIAR BATALLA)

	Este pseudocódigo nos reciba para el apartado de ver y coordinar los turnos tanto de la maquina como del usuario, tambien le
permitirá al usuario poder usar objetos de su inventario y realizar un cambio del jugador si así lo cree convenciente.
	
	Var paso = false
	Var decision_2 = 0
	tableroAJugar = tablero.getTablero()
	Var copiaDelTablero
	
	Desde cont = 0; hasta Longitud del Tablero; 1
		Desde cont = 0; hasta Altura del Tablero; 1
			copiaDelTablero[i][j] = tableroAJugar[i][j]
		findesde
		
	findesde  
	
	Llamar tablero.generarTablero(arboles)
	Llamar seleccionarJugador()
	Llamar seleccionarEnemigos()
	Llamar colocarParticipantes()
	Escribir "BATALLA"
	
	mientras (!salirDelJuego) hacer
		
		Desde cont = 0; hasta 9; 1
			Desde cont = 0; hasta 9; 1
				Escribir tableroAJugar[i][j]
			findesde
			
		findesde
		
		Si (objetos[0] != null || objetos[1] != null) entonces
			Llamar preguntarUtilizacionDeObjetos()
		finsi
		
		Si (jugador[0] != null || jugador[1] != null) entonces
			Llamar preguntarCambioDePersonaje()
		finsi
		
		mientras (!paso) hacer
			Desde cont = 0; hasta 9; 1			
				Desde cont = 0; hasta 9; 1
					Escribir tableroAJugar[i][j]
				findesde
				
			findesde

			Escribir "----------------------------------------------"
			Escribir "Jugador en Batalla:");
			Escribir "  * Nombre:"
			Escribir Llamar jugador[indiceJugadorEnJuego].getNombre()
			Escribir "	* Daño:"
			Escribir Llamar jugador[indiceJugadorEnJuego].getDaño()
			Escribir "	* Vida:"
			Escribir Llamar jugador[indiceJugadorEnJuego].getVida()
			Escribir "----------------------------------------------"
			Escribir "Escribe el Número de la acción que deseas Realizar:"
			Escribir "    1. Mover"
			Escribir "    2. Atacar"
			Escribir "    3. Regresar al Menú Principal"
			Leer decision_2

			Si (decision_2 == 1) entonces
				jugador[indiceJugadorEnJuego].moverPersonaje()
				fila = jugador[indiceJugadorEnJuego].getFila()
				columna = jugador[indiceJugadorEnJuego].getColumna()
				casillaActual = jugador[indiceJugadorEnJuego].getCasillaActual()
				casillaAnterior = casillaActual
				paso = true
			sino(decision_2 == 2) entonces
				Tirar random
				
				Escribir "Información del Jugador:"
				Escribir "--------------------------------------------------------------"
				Si (random < 0.75) entonces
					jugador[indiceJugadorEnJuego].atacarPersonaje()

					Si (enemigos[0] == null && enemigos[1] == null && enemigos[2]) entonces
						ganador = 1
						salirDelJuego = true
					finsi
					
				sino
					Escribir "El Personaje falló el Ataque");
				finsi
				
				Escribir "--------------------------------------------------------------"
				paso = true
				
			sino Si (decision_2 == 3) entonces
				
				mientras (!deseaSalir) hacer
					Escribir "Si sales del Juego no Obtendras Oro"
					Escribir "    1. Salir de todas Formas"
					Escribir "    2. Seguir jugando"
					Leer decision
					
					Si (decision == 1) entonces
						paso = true
						salirDelJuego = true
						deseaSalir = true
					sino Si (decision != 2) entonces
						Llamar imprimirError()
					finsi
					
				finmientras
				
			sino
				Llamar imprimirError()
			finsi
			
		finmientras
		
		Si (ganador == 0) entonces
		
			Si (decision_2 == 1 || decision_2 == 2) entonces
				Escribir "Información del Enemigo:"
				Escribir "--------------------------------------------------------------"
				
				Desde cont = 0; hasta 5; 1		
					Tirar random

					Si (enemigos[i] != null) entonces
					
						Si (random < 0.50) entonces
							enemigos[i].moverPersonaje()
							casillasActuales[i] = enemigos[i].getCasillaActual()
							casillasAnteriores[i] = casillasActuales[i]
						sino
							Tirar random
							
							Si (random_1 < 60) entonces
								enemigos[i].atacarPersonaje()
								
								Si (jugador[0] == null && jugador[1] == null) entonces
									ganador = 2
									salirDelJuego = true
								finsi
								
							sino
								Escribir "El Personaje falló el Ataque"
							finsi
							
						finsi
						
					finsi
					
				findesde
				
				Escribir "--------------------------------------------------------------"
			finsi
			
		finsi
		
	finmientras         
			
	Desde cont = 0; hasta Longitud del Tablero; 1		
		Desde cont = 0; hasta Altura del Tablero; 1		
			tableroAJugar[i][j] = copiaDelTablero[i][j]
		findesde
		
	findesde
--------------------------------------------------------------------------------------------------------------------------------


(PREGUNTAR OBJETOS)

	Este pseudocódigo es utilizado para preguntarle al jugador si desea utilizar algun objeto que tiene en su inventario y si la
respuesta es Si se le presenta un menú con todos objetos disponibles para que pueda decidir que hacer con ellos. De igual se
debe verificar todos los datos que ingrese el usuario.

	Var paso = false
	Var objetoSeleccionado = false
	
	mientras (!paso) hacer
		Escribir "¿Desea utilizar un Objeto?, Escribe el Número de tu Respuesta"
		Escribir "    1. Si"
		Escribir "    2. No"
		Leer decision_1

		Si (decision_1 == 1) entonces
			paso = true
			
			mientras (!objetoSeleccionado) hacer
				Escribir "Escribe el Número del Objeto que desea Utilizar:"
				
				Desde cont = 0; hasta 10; 1	
					Si (objetos[i] != null) entonces
						Escribir "Nombre:"
						Escribir objetos[i].getNombre()
					sino
						Escribir "---------"))
					finsi
					
				findesde
				
				Leer numeroDeObjeto
				
				Si (numeroDeObjeto > 0 && numeroDeObjeto < 11) entonces
					
					Si (objetos[numeroDeObjeto - 1] != null) entonces
					
						Si ("Semilla de la Vida".equals(objetos[numeroDeObjeto - 1].getNombre())) entonces
						
							Si (jugador[0] != null && jugador[1] != null) entonces
								Escribir "Ambos Personajes estan vivos, no puedes usar la Semilla de la Vida")
							sino
								SemillaDeLaVida invocar = (SemillaDeLaVida) objetos[numeroDeObjeto - 1]
								invocar.resucitarPersonaje(jugador, copiaJugador_1, copiaJugador_2)
								notificarPerdidaDePersonaje = false
								objetos[numeroDeObjeto - 1] = null
							finsi
							
							objetoSeleccionado = true
						sino Si ("Elixir Verde".equals(objetos[numeroDeObjeto - 1].getNombre())) entonces
							ElixirVerde invocar = (ElixirVerde) objetos[numeroDeObjeto - 1]
							invocar.recuperarVida(jugador)
							objetos[numeroDeObjeto - 1] = null
							objetoSeleccionado = true
						sino
							CapaDeMovilidad invocar = (CapaDeMovilidad) objetos[numeroDeObjeto - 1]
							invocar.activarCapa()
							fila = invocar.mandarFilaNueva()
							columna = invocar.mandarColumnaNueva()
							jugador[indiceJugadorEnJuego].recibirFila(fila)
							jugador[indiceJugadorEnJuego].recibirColumna(columna)
							objetos[numeroDeObjeto - 1] = null
							objetoSeleccionado = true
						finsi
						
						Desde cont = 0; hasta 10; 1	
							Si (i != 9) entonces
								objetos[i] = objetos[i + 1]
							sino
								objetos[i] = null
							finsi
							
						findesde
						
					sino
						Escribir "------------------------------"
						Escribir "No hay Objetos en esta Casilla"
						Escribir "------------------------------"
					finsi
					
				sino
					Llamar imprimirError()
				finsi
				
			finmientras
			
		sino Si (decision_1 == 2) entonces
			paso = true
		sino
			Llamar imprimirError()
		finsi
		
	finmientras
--------------------------------------------------------------------------------------------------------------------------------


(PREGUNTAR PERSONAJES)

	Este pseudocódigo es utilizado para preguntarle al usuario si desea cambiar al personaje que esta utilizando y en caso solo
tuviera uno se le notificará al usuario una vez y luego no se volverá a preguntar hasta que se termine el juego o hasta que
logre revivir al otro personaje.
	
	Var paso = false
	
	mientras (!paso) hacer  
	
		Si (jugador[0] != null && jugador[1] != null) entonces
			Escribir "¿Desea cambiar de Personaje?, Escribe el Número de tu Respuesta"
			Escribir "    1. Si"
			Escribir "    2. No"
			Leer decision_1

			Si (decision_1 == 1) entonces
			
				Si (indiceJugadorEnJuego == 0) entonces
					indiceJugadorEnJuego = 1
				sino
					indiceJugadorEnJuego = 0
				finsi
				
				tableroAJugar[fila][columna] = jugador[indiceJugadorEnJuego].obtenerLetra()
				jugador[indiceJugadorEnJuego].recibirFila(fila)
				jugador[indiceJugadorEnJuego].recibirColumna(columna)
				paso = true
			sino Si (decision_1 == 2) entonces
				paso = true;
			sino
				Llamar imprimirError()
			finsi
			
		sino Si (jugador[0] == null && jugador[1] == null) entonces
			salirDelJuego = true
		sino
			Si (!notificarPerdidaDePersonaje) entonces
				Si (indiceJugadorEnJuego == 0) entonces
					indiceJugadorEnJuego = 1
				sino
					indiceJugadorEnJuego = 0
				finsi
				tableroAJugar[fila][columna] = jugador[indiceJugadorEnJuego].obtenerLetra()
				jugador[indiceJugadorEnJuego].recibirFila(fila)
				jugador[indiceJugadorEnJuego].recibirColumna(columna)
				notificarPerdidaDePersonaje = true
			finsi
			
			paso = true
		finsi
		
	finmientras
--------------------------------------------------------------------------------------------------------------------------------


(SELECCIONAR PERSONAJE)

	Este pseudocódigo es utlizado para que el usuario escoga cual de los dos personjes que llevo a la batalla quiere utilizar
esto con el fin de colocar a dicho jugador dentro del tablero.
	
	Var opcion = 0
	Var contador = 0
	
	mientras (contador != 1) hacer
		Escribir "            SELECCIÓN (PERSONAJE PRINCIPAL)"
		Escribir "Escriba el Número de su Personaje Principal para la Batalla:"
		Escribir "    1. " + jugador[0].mandarNombre()
		Escribir "    2. " + jugador[1].mandarNombre()
		Leer opcion

		Si (opcion == 1) entonces
			indiceJugadorEnJuego = 0
			Escribir "---------------------------------------------"
			Escribir jugador[0].mandarNombre()
			Escribir "Ha sido Seleccionado como Personaje Principal"
			Escribir "---------------------------------------------"
			contador = 1
		sino Si (opcion == 2) entonces
			indiceJugadorEnJuego = 1
			Escribir "---------------------------------------------"
			Escribir jugador[1].mandarNombre()
			Escribir "Ha sido Seleccionado como Personaje Principal"
			Escribir "---------------------------------------------"
			contador = 1
		sino
			Llamar imprimirError()
		finsi
		
	finmientras
--------------------------------------------------------------------------------------------------------------------------------


(SELECCIONAR ENEMIGO)
	
	Este pseudocódigo es utilizado para poner a los enemigos dentro del tablero segun sea el nivel que el usuario haya escogido
posteriormente se les asigna las casillas donde van a empezar a jugar y se sigue con la ejecusión del programa.

	Var numeroDeEnemigos
	
	Si (nivel == 1) entonces
		numeroDeEnemigos = 2
	sino Si (nivel == 2) entonces
		numeroDeEnemigos = 3
	sino Si (nivel == 3) entonces
		numeroDeEnemigos = 4
	sino
		numeroDeEnemigos = 5
	finsi
	
	Desde cont = 0; hasta numeroDeEnemigos; 1	
		Tirar random para los Personajes
		Personaje nuevoPersonaje = null
		
		Si (personaje < 0.20) entonces
			nuevoPersonaje = new Ogro()
		sino Si (personaje >= 0.20 && personaje < 0.40) entonces
			nuevoPersonaje = new Gargola()
		sino Si (personaje >= 0.40 && personaje < 0.60) entonces
			nuevoPersonaje = new Bruja()
		sino Si (personaje >= 0.60 && personaje < 0.80) entonces
			nuevoPersonaje = new Cancerbero()
		sino
			nuevoPersonaje = new FlorCarnivora()
		finsi
		
		enemigos[i] = nuevoPersonaje
		boolean tieneCasilla = false
		
		mientras (!tieneCasilla) hacer
			Tirar random para la Fila
			Tirar random para la Columna
			
			Si (tableroAJugar[fila][columna] == " ") entonces
				tableroAJugar[fila][columna] = enemigos[i].obtenerLetra()
				enemigos[i].recibirFila(fila)
				enemigos[i].recibirColumna(columna)
				tieneCasilla = true
			finsi
			
		finmientras
		
	findesde
--------------------------------------------------------------------------------------------------------------------------------


(COLOCAR JUGADOR)

	Este pseudocódigo es utilizado luego de que el usuario haya escogido el jugador con el que desea empezar juego, así que por
medio de este subprograma se le asigna un lugar dentro del tablero.

	boolean ponerJugador = false

	mientras (!ponerJugador) hacer
		Tirar random para la Fila
		Tirar random para la Columna

		Si (tableroAJugar[fila][columna] == " ") {
			tableroAJugar[fila][columna] = jugador[indiceJugadorEnJuego].obtenerLetra()
			jugador[indiceJugadorEnJuego].recibirFila(fila)
			jugador[indiceJugadorEnJuego].recibirColumna(columna)
			ponerJugador = true
		finsi
		
	finmientras
--------------------------------------------------------------------------------------------------------------------------------


(MANDAR ORO)

	Este pseudocódigo es utilizado para devolver el oro al jugador si esta gano la partida caso contrario ya sea que pierda o
se salga por su cuenta se le notificará tambien.


	Si (ganador == 1) entonces
		Escribir "------------------"
		Escribir "Ganaste 250 de Oro"
		Escribir "------------------"
		return 250
	sino Si (ganador == 2) entonces
		Escribir "--------"
		Escribir "Perdiste"
		Escribir "--------"
		return 0
	sino
		Escribir "-----------------"
		Escribir "Saliste del juego"
		Escribir "-----------------"
		return 0
	finsi
--------------------------------------------------------------------------------------------------------------------------------


(MOVER PERSONAJE SIN ESPACIOS)

	Este pseudocódigo es utilizado para poder mover al jugador cuando solo tiene que moverse un espacio en cualquier direccion
en este caso por se un personaje jugable se le debe preguntar al jugador antes de cualquier cosa a donde desea moverse luego se
hace el analisis y se determina si se puede mover no, en caso no pudiera moverse se le notifica al usuario y se le pide de que
escoga otra dirección

	Var paso = false
	
	mientras (!paso) hacer 
		Var fila_1 = fila
		Var columna_1 = columna
		Var espacios = movilidad
		Var base = x
		Var altura = y
		Var fila_2 = fila
		Var columna_2 = columna
		Var contador = 0
		Var espaciosLibres = 0
		Var hayObstaculos = false
		Var seMovio = true
		
		Escribir "Escriba una letra a,d,w,s para moverse en esa Dirección:"
		Leer comando
		
		Si (comando == "a" || comando == "d" || comando == "w" || comando == "s") entonces   

			Si (comando == "a") entonces
				columna_1 -= movilidad
				
				Si (columna_1 <= 0) entonces
				
					mientras (columna_1 <= 0) hacer
						columna_1++
						contador++
					finmientras
					
					Si (columna_1 == columna_2) entonces
						seMovio = false
					finsi
					
				finsi
				
			sino Si (comando == "d") entonces
				columna_1 += movilidad
				
				Si (columna_1 >= base) entonces
				
					mientras (columna_1 >= base) hacer
						columna_1--
						contador++
					finmientras
					
					Si (columna_1 == columna_2) entonces
						seMovio = false
					finsi
					
				finsi
				
			sino Si (comando == "w") entonces
				fila_1 -= movilidad
				
				Si (fila_1 <= 0) entonces
				
					mientras (fila_1 <= 0) hacer
						fila_1++
						contador++
					finmientras
					
					Si (fila_1 == fila_2) entonces
						seMovio = false
					finsi
				finsi
				
			sino
				fila_1 += movilidad
				
				Si (fila_1 >= altura) entonces
				
					mientras (fila_1 >= altura) hacer
						fila_1--
						contador++
					finmientras
					
					Si (fila_1 == fila_2) entonces
						seMovio = false
					finsi
					
				finsi
				
			finsi
			
			espacios -= contador
			
			Var restarEspacioProhibidos = espacios
			
			Si (seMovio) entonces
			
				Si (comando == "a") entonces
				
					Desde cont = 1; hasta espacios; 1	

						Si (tablero[fila_2][columna_2 - i] == " " || tablero[fila_2][columna_2 - i] == "L") entonces
							espaciosLibres++
							hayObstaculos = true
						sino
							salir
						finsi
						
					findesde
					
				sino Si (comando == "d") entonces
				
					Desde cont = 1; hasta espacios; 1	

						Si (tablero[fila_2][columna_2 + i] == " " || tablero[fila_2][columna_2 + i] == "L") entonces
							espaciosLibres++;
							hayObstaculos = true;
						sino
							salir
						finsi
						
					findesde
					
				sino Si (comando == "w") entonces
				
					Desde cont = 1; hasta espacios; 1	

						Si (tablero[fila_2 - i][columna_2] == " " || tablero[fila_2 - i][columna_2] == "L") entonces
							espaciosLibres++
							hayObstaculos = true
						sino
							salir
						finsi
						
					findesde
					
				sino Si (comando == "s") entonces
				
					Desde cont = 1; hasta espacios; 1	

						Si (tablero[fila_2 + i][columna_2] == " " || tablero[fila_2 + i][columna_2] == "L") entonces
							espaciosLibres++
							hayObstaculos = true
						sino
							salir
						finsi
						
					findesde
					
				finsi
				
				restarEspacioProhibidos -= espaciosLibres;
				
				Si (espaciosLibres != espacios) entonces
					espacios -= restarEspacioProhibidos
				finsi
				
				Si (hayObstaculos) entonces
					tablero[fila_2][columna_2] = casillaAnterior
					
					Escribir "Información del Jugador:"
					Escribir "----------------------------------------------"
					
					Si (comando == "a") entonces
						casillaActual = tablero[fila_2][columna_2 - espacios]
						tablero[fila_2][columna_2 - espacios] = letra
						columna_2 -= espacios
						Escribir "    * El Caballero se Movio a la Izquierda"
					sino Si (comando == "d") entonces
						casillaActual = tablero[fila_2][columna_2 + espacios]
						tablero[fila_2][columna_2 + espacios] = letra
						columna_2 += espacios
						Escribir "    * El Caballero se Movio a la Derecha"
					sino Si (comando == "w") entonces
						casillaActual = tablero[fila_2 - espacios][columna_2];
						tablero[fila_2 - espacios][columna_2] = letra
						fila_2 -= espacios
						Escribir "    * El Caballero se Movio hacia Arriba"
					sino Si (comando == "s") entonces
						casillaActual = tablero[fila_2 + espacios][columna_2]
						tablero[fila_2 + espacios][columna_2] = letra
						fila_2 += espacios;
						Escribir "    * El Caballero se Movio hacia Abajo"
					finsi
					
					Escribir "----------------------------------------------"
					paso = true
					this.fila = fila_2
					this.columna = columna_2  
				sino
					Escribir "----------------------------------------------"
					Escribir "No puedes pasar por Aquí, Vuelve a Seleccionar"
					Escribir "----------------------------------------------"
				finsi
				
			sino
				Escribir "--------------------------"
				Escribir "Pared, Muevete a otro Lado"
				Escribir "--------------------------"
			finsi
			
		sino
			Escribir "--------------------------------------"
			Escribir "Letra Incorrecto, Intentelo Nuevamente"
			Escribir "--------------------------------------"
		finsi
		
	finmientras
--------------------------------------------------------------------------------------------------------------------------------


(MOVER PERSONAJE CON DISTANCIA)

	Este pseudocódigo es utilizado cuando el personaje puede moverse en diferrentes direcciones y el usuario puede escoger la 
distancia a la que se puede mover el personaje en relación con la movilidad que posea dicho personaje.

	Var paso = false
	Var filasDelTablero = x
	Var columnasDelTablero = y
	
	mientras (!paso) hacer
		Var fila_1 = fila
		Var columna_1 = columna
		Var contador = 0
		Var espaciosLibres = 0
		Var distancia = 0
		Var hayObstaculos = true
		Var seMovio = true
		
		Escribir "Escriba una letra a,d,w,s para moverse en esa Dirección:"
		Leer comando       
		Escribir "Escriba el Número de Espacios que desea moverse entre el rango de 1 a"
		Escribir movilidad
		Leer distancia
		
		Si (comando == "a" || comando == "d" || comando == "w" || comando == "s") entonces
		
			Si (distancia > 0 && distancia <= movilidad) entonces
			
				Si (comando == "a") entonces
					columna_1 -= distancia

					Si (columna_1 <= 0) entonces
						mientras (columna_1 <= 0) hacer
							columna_1++
							contador++
						finmientras
						
					finsi
					
				sino Si (comando == "d") entonces
					columna_1 += distancia

					Si (columna_1 >= columnasDelTablero) entonces
						mientras (columna_1 >= columnasDelTablero) hacer
							columna_1--
							contador++
						finmientras
						
					finsi
					
				sino Si (comando == "w") entonces
					fila_1 -= distancia

					Si (fila_1 <= 0) entonces
						mientras (fila_1 <= 0) hacer
							fila_1++
							contador++
						finmientras
						
					finsi
					
				sino
					fila_1 += distancia

					Si (fila_1 >= filasDelTablero) entonces
						mientras (fila_1 >= filasDelTablero) hacer
							fila_1--
							contador++
						finmientras
						
					finsi
					
				finsi
				
				Si (fila_1 == fila && columna_1 == columna) entonces
					seMovio = false
				finsi

				distancia -= contador

				Si (seMovio) entonces      
					Si (comando == "a") entonces
					
						Desde i = 1; hasta distancia; 1

							si (tablero[fila][columna - i] == " ." || tablero[fila][columna - i] == " L" || tablero[fila][columna - i] == " A" || tablero[fila][columna - i] == " a") entonces
								espaciosLibres++
								hayObstaculos = false
							sino
								salir
							finsi
							
						findesde
						
					sino Si (comando.equals("d")) entonces
					
						Desde i = 1; hasta distancia; 1

							Si (tablero[fila][columna + i] == " ." || tablero[fila][columna + i] == " L" || tablero[fila][columna + i] == " A" || tablero[fila][columna + i] == " a") entonces
								espaciosLibres++
								hayObstaculos = false
							sino
								salir
							finsi
							
						findesde
						
					sino Si (comando.equals("w")) entonces
					
						Desde i = 1; hasta distancia; 1

							Si (tablero[fila - i][columna] == " ." || tablero[fila - i][columna] == " L" || tablero[fila - i][columna] == " A" || tablero[fila - i][columna] == " a") entonces
								espaciosLibres++
								hayObstaculos = false
							sino
								salir
							finsi
							
						findesde
						
					sino Si (comando.equals("s")) entonces
					
						Desde i = 1; hasta distancia; 1

							Si (tablero[fila + i][columna] == " ." || tablero[fila + i][columna] == " L" || tablero[fila + i][columna] == " A" || tablero[fila + i][columna] == " a") entonces
								espaciosLibres++
								hayObstaculos = false
							sino
								salir
							finis
							
						findesde
						
					finsi

					Si (!hayObstaculos) entonces
						tablero[fila][columna] = casillaAnterior

						Si (distancia != espaciosLibres) entonces
							int espaciosARestar = distancia - espaciosLibres
							distancia -= espaciosARestar
						finsi

						Escribir "Información del Jugador:"
						Escribir "-------------------------------------------"
						
						Si (comando.equals("a")) entonces
							casillaActual = tablero[fila][columna - distancia]
							tablero[fila][columna - distancia] = letra
							columna -= distancia
							Escribir "    * El Dragón se Movio a la Izquierda")
						sino Si (comando.equals("d")) entonces
							casillaActual = tablero[fila][columna + distancia]
							tablero[fila][columna + distancia] = letra
							columna += distancia
							Escribir "    * El Dragón se Movio a la Derecha"
						sino Si (comando.equals("w")) entonces
							casillaActual = tablero[fila - distancia][columna]
							tablero[fila - distancia][columna] = letra
							fila -= distancia
							Escribir "    * El Dragón se Movio hacia Arriba"
						sino Si (comando == "s") entonces
							casillaActual = tablero[fila + distancia][columna]
							tablero[fila + distancia][columna] = letra
							fila += distancia
							Escribir "    * El Dragón se Movio hacia Abajo"
						finsi
						
						Escribir "-------------------------------------------"
						paso = true 
					sino
						Escribir "----------------------------------------------"
						Escribir "No puedes pasar por Aquí, Vuelve a Seleccionar"
						Escribir "----------------------------------------------"
					finsi
					
				sino
					Escribir "--------------------------------"
					Escribir "Pared, selecciona otra Dirección"
					Escribir "--------------------------------"
				finsi
				
			sino
				Escribir "---------------------------------------"
				Escribir "Número Incorrecto, Intentelo Nuevamente"
				Escribir "---------------------------------------"
			finsi
			
		sino
			Escribir "--------------------------------------"
			Escribir "Letra Incorrecto, Intentelo Nuevamente"
			Escribir "--------------------------------------"
			
			Si (distancia <= 0 || distancia > movilidad) entonces
				Escribir "---------------------------------------"
				Escribir "Número Incorrecto, Intentelo Nuevamente"
				Escribir "---------------------------------------"
			finsi
			
		finsi
		
	finmientras
--------------------------------------------------------------------------------------------------------------------------------


(ATACAR PERSONAJE AL SU ALREDEDOR)

	Este pseudocódigo es utilizado cuando tanto el jugador como el enemigo tiene un personaje que tenga que golpear a cualquier
personaje a una distancia de una casilla a su alrededor.

	Var uno = true
	Var dos = true
	Var tres = true
	Var cuatro = true
	Var cinco = true
	Var seis = true
	Var siete = true
	Var ocho = true
	Var encontroAlgo = false
	Var enemigosDetectados 

	if (fila == 1 && columna == 1) entonces
		uno = dos = tres = cuatro = seis = false
	sino Si (fila == 1 && columna != 1 && columna != y - 1) entonces
		uno = dos = tres = false
	sino Si (fila == 1 && columna == y - 1) entonces
		uno = dos = tres = cinco = ocho = false
	sino Si (columna == 1 && fila != 1 && fila != x - 1) entonces
		uno = cuatro = seis = false
	sino Si (columna == y - 1 && fila != 1 && fila != x - 1) entonces
		tres = cinco = ocho = false
	sino Si (fila == x - 1 && columna == 1) entonces
		uno = cuatro = seis = siete = ocho = false
	sino Si (fila == x - 1 && columna != 1 && columna != y - 1) entonces
		seis = siete = ocho = false
	sino Si (fila == x - 1 && columna == y - 1) entonces
		tres = cinco = seis = siete = ocho = false
	finsi
	
	Si (uno) entonces
		Si (" O" == tablero[fila - 1][columna - 1] || " g" == tablero[fila - 1][columna - 1] || " B" == tablero[fila - 1][columna - 1] || " c" == tablero[fila - 1][columna - 1] || " F" == tablero[fila - 1][columna - 1] || " A" == tablero[fila - 1][columna - 1]) entonces
			enemigosDetectados[0][0] = fila - 1
			enemigosDetectados[0][1] = columna - 1
		finsi
		
	finsi
	Si (dos) entonces
		Si (" O" == tablero[fila - 1][columna] || " g" == tablero[fila - 1][columna] || " B" == tablero[fila - 1][columna] || " c" == tablero[fila - 1][columna] || " F" == tablero[fila - 1][columna] || " A" == tablero[fila - 1][columna]) entonces
			enemigosDetectados[1][0] = fila - 1
			enemigosDetectados[1][1] = columna
		finsi
		
	finsi
	Si (tres) entonces
		Si (" O" == tablero[fila - 1][columna + 1] || " g" == ablero[fila - 1][columna + 1] || " B" == tablero[fila - 1][columna + 1] || " c" == tablero[fila - 1][columna + 1] || " F" == tablero[fila - 1][columna + 1] || " A" == tablero[fila - 1][columna + 1]) entonces
			enemigosDetectados[2][0] = fila - 1
			enemigosDetectados[2][1] = columna + 1
		finsi
		
	finsi
	Si (cuatro) entonces
		Si (" O" == tablero[fila][columna - 1] || " g" == tablero[fila][columna - 1] || " B" == tablero[fila][columna - 1] || " c" == tablero[fila][columna - 1] || " F" == tablero[fila][columna - 1] || " A" == tablero[fila][columna - 1]) entonces
			enemigosDetectados[3][0] = fila
			enemigosDetectados[3][1] = columna - 1
		finsi
		
	finsi
	Si (cinco) entonces
		Si (" O" == tablero[fila][columna + 1] || " g" == tablero[fila][columna + 1] || " B" == tablero[fila][columna + 1] || " c" == tablero[fila][columna + 1] || " F" == tablero[fila][columna + 1] || " A" == tablero[fila][columna + 1]) entonces
			enemigosDetectados[4][0] = fila
			enemigosDetectados[4][1] = columna + 1
		finsi
		
	finsi
	Si (seis) entonces
		Si (" O" == tablero[fila + 1][columna - 1] || " g" == tablero[fila + 1][columna - 1] || " B"tablero[fila + 1][columna - 1] || " c" == tablero[fila + 1][columna - 1] || " F" == tablero[fila + 1][columna - 1] ||" A" == tablero[fila + 1][columna - 1]) entonces
			enemigosDetectados[5][0] = fila + 1
			enemigosDetectados[5][1] = columna - 1
		finsi
		
	finsi
	Si (siete) entonces
		Si (" O" == tablero[fila + 1][columna] || " g" == tablero[fila + 1][columna] || " B" == tablero[fila + 1][columna] || " c" == tablero[fila + 1][columna] || " F" == tablero[fila + 1][columna] || " A" == tablero[fila + 1][columna]) entonces
			enemigosDetectados[6][0] = fila + 1
			enemigosDetectados[6][1] = columna
		finsi
		
	finsi
	Si (ocho) entonces
		Si (" O" == tablero[fila + 1][columna + 1] || " g" == tablero[fila + 1][columna + 1] || " B" == tablero[fila + 1][columna + 1] || " c" == tablero[fila + 1][columna + 1] || " F" == tablero[fila + 1][columna + 1] || " A" == tablero[fila + 1][columna + 1]) entonces
			enemigosDetectados[7][0] = fila + 1
			enemigosDetectados[7][1] = columna + 1
		finsi
		
	finsi
	
	Tirar random
	
	Si (random < porcentajeDeEfectividad) entonces
	
		Escribir "Información del Jugador:"
		Escribir "--------------------------------------------------------------"
		
		Desde i= 0; hasta 5; 1
		
			Si (arboles[i] != null) entonces
			
				Desde j = 0; hasta 8; 1
					Si (arboles[i].getFila() == enemigosDetectados[j][0] && arboles[i].getColumna() == enemigosDetectados[j][1]) {
						arboles[i].setVida(daño);

						Si (arboles[i].getVida() == 0) entonces
							tablero[arboles[i].getFila()][arboles[i].getColumna()] = " ."
							arboles[i] = null
							Escribir "    * Caballero destruyó un Árbol"
						sino
							Escribir "    * Caballero hizó un daño al Árbol pero sigue de Pie"
						finsi
						encontroAlgo = true
					finsi
					
				findesde
				
			finsi
			
		findesde
		
		for (int i = 0; i < 5; i++) entonces
		
			if (enemigos[i] != null) entonces
			
				Desde j = 0; hasta 8; 1	
				
					Si (enemigos[i].getFila() == enemigosDetectados[j][0] && enemigos[i].getColumna() == enemigosDetectados[j][1]) {
						enemigos[i].aumentarOQuitarVida(-daño)

						Si (enemigos[i].obtenerVida() == 0) entonces
							tablero[enemigos[i].getFila()][enemigos[i].getColumna()] = " ."
							Escribir "    * Caballero dejo fuera de Combate a "
							Escribir enemigos[i].mandarNombre()
							enemigos[i] = null
						sino
							Escribir "    * Caballero atacó a " 
							Escribir enemigos[i].mandarNombre() 
							Escribir " dejandoló con " 
							Escribir enemigos[i].obtenerVida()
							Escribir " de vida"
						finsi
						
						encontroAlgo = true
					finsi
					
				findesde
				
			finsi
			
		findesde
		
		Si (!encontroAlgo) entonces
			Escribir "    * Caballero realizó su Ataque pero no habia Enemigos Cerca"
		finsi
		
		Escribir "--------------------------------------------------------------"
	sino
		Escribir "Información del Jugador:"
		Escribir "------------------------------------------------------"
		Escribir "    * El Caballero falló en el Ataque");
		Escribir "------------------------------------------------------"
	finsi
--------------------------------------------------------------------------------------------------------------------------------


(ATACAR PERSONAJE EN UNA DIRECCION)

	Este pseudocódigo es utilizado cuando el jugador desea atacar en una direccion espeficia y dentro de este código le sera 
verificada la información de modo de que si no es posible realizar el ataque se el notificará al jugador de igual manera por
medio de este codigo se controla la efectividad del personaje y si hace daño también se le notificará al usuario.

	Var distanciaColumna = 0
	Var distanciaFila = 0
	Var direccionCorrecta = false
	Var encontroAlgo = false
	Var comando = null
	
	mientras (!direccionCorrecta) hacer
		boolean paso = true
		distanciaFila = 0
		distanciaColumna = 0
		Escribir "Escriba una letra a,d,w,s para atacar en esa Dirección:"
		Leer comando
		
		Si (comando == "a") entonces
			distanciaColumna = columna - 2
			distanciaFila = fila
			
			mientras (distanciaColumna <= 0) hacer
				distanciaColumna++
			finmientras
			
		sino Si (comando == "d") entonces
			distanciaColumna = columna + 2
			distanciaFila = fila
			
			mientras (distanciaColumna >= y) hacer
				distanciaColumna--
			finmientras
			
		sino Si (comando == "w") entonces
			distanciaFila = fila - 2
			distanciaColumna = columna
			
			mientras (distanciaFila <= 0) hacer
				distanciaFila++
			finmientras
			
		sino Si (comando == "s") entonces
			distanciaFila = fila + 2
			distanciaColumna = columna
			
			mientras (distanciaFila >= x) hacer
				distanciaFila--
			finmientras
			
		sino
			Escribir "--------------------------------------"
			Escribir "Letra Incorrecta, Intentalo Nuevamente"
			Escribir "--------------------------------------"
			paso = false
		finsi
		
		Si (paso) entonces
			Si (distanciaColumna == columna && distanciaFila == fila) entonces
				Escribir "-------------------------------------------------------"
				Escribir "No puede atacar en esta Direccion, Intentalo Nuevamente"
				Escribir "-------------------------------------------------------"
				direccionCorrecta = false
			sino
				direccionCorrecta = true
			finsi
			
		finsi
		
	finmientras
	
	Var espaciosDisponibles
	
	Si (comando == "a") entonces
		espaciosDisponibles = columna - distanciaColumna
	sino Si (comando == "d") entonces
		espaciosDisponibles = distanciaColumna - columna
	sino Si (comando == "w") entonces
		espaciosDisponibles = fila - distanciaFila
	sino
		espaciosDisponibles = distanciaFila - fila
	finsi
	
	Tirar un random
	
	Si (random < porcentajeDeEfectividad) entonces
		Escribir "Información del Jugador:"
		Escribir "------------------------------------------------------------"
		
		Desde i = 1; hasta espaciosDisponibles; 1
			Var filaAtacada = 100
			Var columnaAtacada = 100

			Si (comando == "a") entonces
				Si (tablero[fila][columna - i] == " O" || tablero[fila][columna - i] == " g" || tablero[fila][columna - i] == " B" || tablero[fila][columna - i] == " c"|| tablero[fila][columna - i] == " F" || tablero[fila][columna - i] == " A") entonces
					filaAtacada = fila
					columnaAtacada = columna - i
				finsi
				
			sino Si (comando == "d") {
				Si (tablero[fila][columna + i] == " O" || tablero[fila][columna + i] == " g" || tablero[fila][columna + i] == " B" || tablero[fila][columna + i] == " c" || tablero[fila][columna + i] == " F" || tablero[fila][columna + i] == " A") entonces
					filaAtacada = fila
					columnaAtacada = columna + i
				finsi
				
			sino Si (comando == "w") {
				Si (tablero[fila - i][columna ] == " O" || tablero[fila - i][columna] == " g" || tablero[fila - i][columna] == " B" || tablero[fila - i][columna] == " c" || tablero[fila - i][columna] == " F" || tablero[fila - i][columna] == " A") entonces
					filaAtacada = fila - i
					columnaAtacada = columna
				finsi
				
			sino
				Si (tablero[fila + i][columna ] == " O" || tablero[fila + i][columna] == " g" || tablero[fila + i][columna] == " B" || tablero[fila + i][columna] == " c" || tablero[fila + i][columna] == " F" || tablero[fila + i][columna] == " g") entonces
					filaAtacada = fila + i;
					columnaAtacada = columna;
				finsi
				
			finsi

			Desde j = 0; hasta 5; 1
			
				Si (arboles[j] != null) entonces
				
					Si (arboles[j].getFila() == filaAtacada && arboles[j].getColumna() == columnaAtacada) entonces
						arboles[j].setVida(daño);

						Si (arboles[j].getVida() == 0) entonces
							tablero[filaAtacada][columnaAtacada] = " ."
							arboles[j] = null
							Escribir "    * Dragón destruyó un Árbol"
						sino
							Escribir "    * Dragón hizó un daño de "
							Escribir daño
							Escribir " al Árbol pero sigue de Pie"
						finsi
						
						encontroAlgo = true
					finsi
					
				finsi
				
			findesde
			
			Desde i = 0; hasta 5; 1
			
				Si (enemigos[j] != null) entonces
				
					Si (enemigos[j].getFila() == filaAtacada && enemigos[j].getColumna() == columnaAtacada) entonces
						enemigos[j].aumentarOQuitarVida(-daño)

						Si (enemigos[j].obtenerVida() == 0) entonces
							tablero[filaAtacada][columnaAtacada] = enemigos[j].getCasillaActual()
							Escribir "    * Dragón dejo fuera de Combate a " + enemigos[j].mandarNombre()
							enemigos[j] = null
						sino
							Escribir "Dragón atacó a" 
							Escribir enemigos[j].mandarNombre()
							Escribir " dejandoló con "
							Escribir enemigos[j].obtenerVida()
							Escribir" de vida"
						finsi
						
						encontroAlgo = true
					finsi
					
				finsi
				
			findesde
			
		findesde
		
		Si (!encontroAlgo) entonces
			Escribir "    * Dragón realizó su Ataque pero no habia Objetivos Cerca"
		finsi
		
		Escribir "------------------------------------------------------------"
	sino
		Escribir "Información del Jugador:"
		Escribir "------------------------------------------------------"
		Escribir "    * El Dragón falló en el Ataque"
		Escribir "------------------------------------------------------"
	finsi
--------------------------------------------------------------------------------------------------------------------------------


(ATACAR PERSONAJE EN UNA DIRECCION CON DISTANCIA)

	Este pseudocódigo es utilizado cuando el pesonaje ataca y hay que espeficicarle dos cosas la primera la dirección y la
distancia a la que desea atacar, corrovorando los datos y dando infomación al jugador acerca de lo que paso.

	Var direccionCorrecta = false
	Var distanciaFila = 0
	VardistanciaColumna = 0
	
	mientras (!direccionCorrecta) hacer
		distanciaFila = 0
		distanciaColumna = 0
		Escribir Escriba una letra a,d,w,s para atacar en esa Dirección:"
		Leer comando
		Escribir "Escriba el Número de Espacios a la que desea enviar el Ataque entre el Rango de 1 a 3"
		Leer distancia

		Si ("a".equals(comando) || "d".equals(comando) || "w".equals(comando) || "s".equals(comando)) entonces
		
			Si (distancia > 0 && distancia < 4) entonces
			
				Si (comando == "a") entonces
					distanciaColumna = columna - distancia
					distanciaFila = fila
					
					mientras (distanciaColumna <= 0) hacer
						distanciaColumna++
					finmientras
					
				sino Si (comando == "d") entonces
					distanciaColumna = columna + distancia
					distanciaFila = fila

					mientras (distanciaColumna >= y) hacer
						distanciaColumna--
					finmientras
					
				sino Si (comando == "w") entonces
					distanciaFila = fila - distancia
					distanciaColumna = columna

					mientras (distanciaFila <= 0) hacer
						distanciaFila++
					finmientra
					
				sino Si (comando == "s") entonces
					distanciaFila = fila + distancia
					distanciaColumna = columna

					mientras (distanciaFila >= x) hacer
						distanciaFila--
					finmientras
					
				finsi
				direccionCorrecta = true
			sino
				Escribir "---------------------------------------"
				Escribir "Número Incorrecto, Intentelo Nuevamente"
				Escribir "---------------------------------------"
			finsi
			
		sino
			Escribir "--------------------------------------"
			Escribir "Letra Incorrecta, Intentelo Nuevamente"
			Escribir "--------------------------------------"
			
			Si (distancia <= 0 || distancia > movilidad) entonces
				Escribir "---------------------------------------"
				Escribir "Número Incorrecto, Intentelo Nuevamente"
				Escribir "---------------------------------------"
			finsi
			
		finsi
		
		Si (distanciaColumna == columna && distanciaFila == fila) entonces
			Escribir "-----------------------------------------------"
			Escribir "Pared, selecciona otra Dirección para el Ataque"
			Escribir "-----------------------------------------------"
			direccionCorrecta = false
		finsi
		
	finmientras
	
	Tirar random
	
	Si (random < porcentajeDeEfectividad) entonces
	
		Escribir "Información del Jugador:"
		Escribir "----------------------------------------------------------------------"
		
		Si (tablero[distanciaFila][distanciaColumna] == " O" || tablero[distanciaFila][distanciaColumna] == " g" || tablero[distanciaFila][distanciaColumna] == " B" || tablero[distanciaFila][distanciaColumna] == " c" || tablero[distanciaFila][distanciaColumna] == " F" || tablero[distanciaFila][distanciaColumna] == " A") entonces

			Desde i = 0; hasta 5; 1
				Si (arboles[i] != null) entonces
					Si (arboles[i].getFila() == distanciaFila && arboles[i].getColumna() == distanciaColumna) entonces
						arboles[i].setVida(daño)

						Si (arboles[i].getVida() == 0) entonces
							tablero[distanciaFila][distanciaColumna] = " ."
							arboles[i] = null
							Escribir "    * Arquero destruyó un Árbol"
						sino
							Escribir "    * Arquero hizo un daño de " + daño + " al Árbol pero sigue de Pie"
						finsi
						
					finsi
					
				finsi
				
			findesde
			
			Desde i = 0; hasta 5; 1
			
				Si (enemigos[i] != null) entonces
				
					Si (enemigos[i].getFila() == distanciaFila && enemigos[i].getColumna() == distanciaColumna) entonces
						enemigos[i].aumentarOQuitarVida(-daño)

						Si (enemigos[i].obtenerVida() == 0) entonces
							tablero[distanciaFila][distanciaColumna] = enemigos[i].getCasillaActual()
							Escribir "    * Arquero dejo fuera de Combate a "
							Escribir enemigos[i].mandarNombre()
							enemigos[i] = null
						sino
							Escribir "    * Arquero atacó a "
							Escribir enemigos[i].mandarNombre()
							Escribir " dejandoló con "
							Escribir enemigos[i].obtenerVida()
							Escribir " de vida"
						finsi
					finsi
					
				finsi
				
			findesde
		sino
			Escribir "    * Arquero realizó su Ataque pero no habia Objetivos en esa Casilla"
		finsi
		Escribir"----------------------------------------------------------------------"
	sino
		Escribir "Información del Jugador:"
		Escribir "------------------------------------------------------"
		Escribir "    * El Arquero falló en el Ataque"
		Escribir "------------------------------------------------------"
	finsi