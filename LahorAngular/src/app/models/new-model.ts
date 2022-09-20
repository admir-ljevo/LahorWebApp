export class NewModel{
    id:Number;
    name:string;
    userId:Number;
    image:any;
    text:string;
    public:boolean;
    file:any;
    constructor() {

    this.id=0;
    this.name="";
    this.userId=+localStorage.getItem("user-id")!;
    this.image=null;
    this.text="";
    this.public=false;
    this.file=null;
    }
  }
