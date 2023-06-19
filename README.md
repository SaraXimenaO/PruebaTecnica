# PruebaTecnica
Este api obtiene la información de los recaudos de un api externo y los guarda en la DB para luego consultarlos y mostrarlos en una tabla y un reprote en pdf

# Requisitos previos
1. Instalar net framework 6

# Instalación

Obtener los cambios de la rama master localmente
Compilar el proyecto y ejecutar

# Uso

Consumir los endpoints correspondientes 

Ejemplo para Obtener recaudos

  GetRecaudo(date: string): Observable<recaudo[]> {
        return this.http.get<recaudo[]>(`https://localhost:7097/PruebaTecnica/${date}`);
      }

      Ejemplo para El reporte

       GetReport(date: string): Observable<report[]> {
            return this.http.get<report[]>(`https://localhost:7097/PruebaTecnica/Report/${date}`);
          }

# Diagrama de componentes
![image](https://github.com/sxxor/PruebaTecnica/assets/7612153/c7ca86b6-80b1-4b64-a513-9c0d84ddfefe)
