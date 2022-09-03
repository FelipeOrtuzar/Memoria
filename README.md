# Memoria

## Título

DISEÑO Y DESARROLLO DE PROTOTIPO DE APLICACIÓN EN REALIDAD
VIRTUAL COMO COMPLEMENTO DE TERAPIAS DE EXPOSICIÓN CONTROLADA
PARA EL MANEJO DE FOBIAS

## Requerimientos

Para el asegurar el correcto funcionamiento del programa, se recomienda instalar o asegurarse de que los siguientes componentes estén presentes al utilizar el programa.

- El programa fue desarrollado utilizando un Oculus Quest 1, así que se recomienda utilizar este hardware

- Utilizar la versión 2020.3.23f1 del editor de Unity. De no hacerlo algunas Mallas pierden visibilidad. Además se le debe instalar el modulo Android Build Support.

- Utilizar el Universal Render Pipeline para el procedimiento gráfico, si se observan muchas texturas rosas es posible que haya un problema ahí.

- Los plugins necesarios de installar en el Package Manager son: Oculus XR Plugin, Universal RP, XR interaction Toolkit, XR Plugin Management. De querer editar la estructura de la casa se recomienda el plugin ProBuilder.

- En la Build Settings asegurarse de que estén las escenas Menu, Bosque, Casa y Tutorial. Pero de querer buildear la aplicación al Oculus es posible que el Bosque crashee el build debido a la existencia del terreno.

- Asegurarse que en el Proyect Settings->XR Plug-in Management estén chequeados los boxes del Build para Oculus.

## Errores que podrían aparecer en la instalación

- Si algunas texturas aparecen rosadas puede ser que el editor no las esté reconociendo: Revisar en que Shader se están procesando las texturas, en general debería ser en Universal Render Pipeline/Lit.

- Si el jugador empieza a flotar al empezar el programa, probablemente se deba a que se perdieron las Layers. Para esto se debe crear una capa llamada "Ground" y asignarla a todos los lugares donde el jugador podría caminar.