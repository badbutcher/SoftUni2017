class Dialog {
    constructor(textMessage, callback) {
        this.textMessage = textMessage;
        this.callback = callback;
    }


    addInput(label, name, type) {

    }

    render() {
        return `<div class="overlay">
  <div class="dialog">
    <p>Dialog, containing message text and input field.</p>
    <label>Name</label>
    <input name="name" type="text">
    <button>OK</button>
    <button>Cancel</button>
  </div>
</div>		
`;
    }
}
