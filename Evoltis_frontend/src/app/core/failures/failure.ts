export abstract class Failure {
    constructor(
      public message:string,
      public code: number
    ) {}
  }
  
  export class UnhandledFailure extends Failure {
    constructor(message:string = 'No se pudo realizar la operación', code:number) {
      super(message, code);
    }
  }
  
  export class ExistingEmail extends Failure {
    constructor(){
      super('El email ingresado ya existe',400);
    }
  }
  
  export class NotFound extends Failure {
    constructor(message:string){
      super(`No se encontraron ${message}`,404);
    }
  }
  
  export class BadRequestFailure extends Failure {
    constructor(message: string = 'Los datos enviados son incorrectos'){
      super(message,400);
    }
  }
  
  export class ExecutionFailure extends Failure {
    constructor(){
      super(`Algo anda mal. Comuniquese con el administrador`,500);
    }
  }