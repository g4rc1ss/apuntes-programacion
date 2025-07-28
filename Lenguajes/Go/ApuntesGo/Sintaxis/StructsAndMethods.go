package main

import "fmt"

type Person struct {
	Name string
	Age  int
}

func (p Person) name() {
	fmt.Println("Hola", p.Name)
}
