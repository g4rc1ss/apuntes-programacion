package main

func main() {
	var hola IHola

	hola = Hola{}

	hola.Execute()

}

type IHola interface {
	Execute()
	Execute2()
}

type Hola struct {
}

func (h Hola) Execute2() {
	//TODO implement me
	panic("implement me")
}

func (h Hola) Execute() {

}
