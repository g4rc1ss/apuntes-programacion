package main

func main() {
	// Pointers
	valor := 2
	pointer(&valor)

	// Structs
	p := Person{Name: "Asier", Age: 28}
	p.name()

	// Interfaces with goroutines
	execute()
}
