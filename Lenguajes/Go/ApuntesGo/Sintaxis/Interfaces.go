package main

import (
	"sync"
	"time"
)

var wg sync.WaitGroup

func execute() {
	var hola IHola

	hola = Hola{}

	wg.Add(1)

	go hola.Execute()

	hola.Execute2()

	wg.Wait()

}

type IHola interface {
	Execute()
	Execute2()
}

type Hola struct {
}

func (h Hola) Execute2() {
	println("Ejecutando")
}

func (h Hola) Execute() {
	time.Sleep(10 * time.Second)
	println("Ejecutando despues del tiempo")
	wg.Done()
}
