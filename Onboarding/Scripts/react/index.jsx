import React from "react"
import ReactDOM from "react-dom"

export default class Example extends React.Component {

    render() {
        return (
            <div>               
                <p>Hello again</p>                
            </div>
        )
    }
}


const root = document.getElementById("root")
ReactDOM.render(<Example />, root)