import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

class Table extends Component {
    constructor(props) {
        super(props);
        this.handleDelete = this.handleDelete.bind(this);
    }

    handleDelete(id) {
        debugger;
        if (!id) {
            console.error("ID is undefined, cannot delete.");
            return;
        }

        axios.delete(`http://localhost:5250/api/Student`)
        
            .then(response => {
                console.log("Delete successful:", response.data);
               
                this.props.history.push('/Studentlist');
            })
            .catch(error => {
                console.error("There was an error deleting the student:", error);
            });
    }

    render() {
        return (
            <tr>
                <td>
                    {this.props.obj.name}
                </td>
                <td>
                    {this.props.obj.rollno}
                </td>
                <td>
                    {this.props.obj.class}
                </td>
                <td>
                    {this.props.obj.address}
                </td>
                <td>
                    {this.props.obj.gender}
                </td>
                <td>
                    <Link to={"/edit/" + this.props.obj.id} className="btn btn-success">Edit</Link>
                </td>
                <td>
                    <button type="button" onClick={this.DeleteStudent} className="btn btn-danger">Delete</button>
                </td>
            </tr>
        );
    }
}

export default Table;