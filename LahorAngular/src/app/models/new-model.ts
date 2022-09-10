export class NewModel{
    id:Number;
    name:string;
    userId:Number;
    image:string;
    text:string;
    public:boolean;

    constructor() {

this.id=0;
this.name="";
this.userId=+localStorage.getItem("user-id");
this.image="";
this.text="";
this.public=false;
}
  }