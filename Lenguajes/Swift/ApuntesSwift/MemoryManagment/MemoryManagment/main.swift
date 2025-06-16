//
//  main.swift
//  MemoryManagment
//
//  Created by Asier Garcia Barrenengoa on 2/1/25.
//

import Foundation

var lista = [PruebaObjeto]()

for i in 0...1_000_000 {
    lista.append(PruebaObjeto(texto: i))
}
print("Limpiamos la lista")
lista.removeAll()

pruebaFunction()

func pruebaFunction() {
    var array = [PruebaObjeto]()
    for i in 0...1_000_000 {
        array.append(PruebaObjeto(texto: i))
    }
}
