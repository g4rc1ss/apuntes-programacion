#[repr(C)]
pub struct MyStruct {
    pub a: i32,
    pub b: f64,
}

#[unsafe(no_mangle)]
pub extern "C" fn create_struct(a: i32, b: f64) -> MyStruct {
    MyStruct { a, b }
}

#[unsafe(no_mangle)]
pub extern "C" fn create_struct_ptr(a: i32, b: f64) -> *mut MyStruct {
    let boxed = Box::new(MyStruct { a, b });
    Box::into_raw(boxed)
}

#[unsafe(no_mangle)]
pub extern "C" fn destroy_struct_ptr(ptr: *mut MyStruct) {
    if !ptr.is_null() {
        unsafe {
            let x = Box::from_raw(ptr);
            let x_string = x.a.to_string();
            println!("{}", x_string);
        };
    }
}
