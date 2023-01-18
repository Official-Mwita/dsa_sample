

//Start
//Load data here from user

//Define classes here
class Student {
    constructor(firstName, lastName, grade, email) {
        this._firstName = firstName;
        this._lastName = lastName;
        this._grade = grade;
        this._email = email;
    }

    get FirstName() {
        return this._firstName;
    }

    get LastName() {
        return this._lastName;
    }

    get Grade() {
        return this._grade;
    }

    get Email() {
        return this._email;
    }
}
class Node {

    constructor(data) {
        this._data = data;
        this._next = null;
        this._prev = null;
    }

    get Next() {
        return this._next;
    }

    set Next(value) {
        this._next = value;
    }

    get Prev() {
        return this._prev;
    }

    set Prev(value) {
        this._prev = value;
    }

    get Data() {
        return this._data;
    }
}

class D_LinkedList {
    constructor() {
        this._size = 0;
        this._head = null;
        this._current = null;
    }

    get Size() {
        return this._size;
    }

    set Size(value) {
        this._size = value;
    }

    get Head() {
        return this._head;
    }

    set Head(value) {
        this._head = value;
    }

    get Current() {
        return this._current;
    }

    set Current(value) {
        this._current = value;
    }
}

//Making node test

//var student1 = new Student("Mwita", "Joseph", "A+", "mymail@mail.com");
//var student2 = new Student("Mwita2", "Joseph2", "A", "mymail@mail.com2");

//var node1 = new Node(student1);
//var node2 = new Node(student2);

// node1.Next = node2;

// console.log(student1);
// console.log(student2);
// console.log(node2);
// console.log(node1);




//on load
var mylist = new D_LinkedList();

//Disable buttons
document.getElementById("leftbtn").disabled = true;
document.getElementById("rightbtn").disabled = true;

fetch('/Home/StudentsAPI')
    .then(response => response.json())
    .then(data => {
        createList(data);
    })
    .catch(error => console.error(error));






//InsertNode(mylist, student1);
//InsertNode(mylist, student2);


// console.log(mylist.Current);
// TraverseRight(mylist);
// TraverseRight(mylist);
// console.log("After second traversal");
// console.log(mylist.Current);
// TraverseLeft(mylist);
// TraverseLeft(mylist);
// TraverseLeft(mylist);
// console.log("Back traversal");
// console.log(mylist.Current);




// //Define linked list functions
function InsertNode(list, data) {
    //Create the new node
    let _Node = new Node(data);

    //Check if head is set. Otherwise set this to head
    if (list.Head === null) {
        list.Head = _Node;
    }
    else //Get last node then instert it properly
    {
        let last = GetLast(list);
        last.Next = _Node;
        _Node.Prev = last;

    }

    //After every addition increment
    list.Size += 1;

}


function GetLast(list) {
    let _Node = list.Head;

    if (_Node === null) {
        return _Node;
    }

    while (_Node.Next != null) {
        _Node = _Node.Next;

    }

    return _Node;

}

function createList(data) {

    //Create a list

    data.map(value => {

        InsertNode(mylist, new Student(value.firstName, value.lastName, value.studentGrade, value.studentEmail));
    });

    //Traverse twice. Done at server
    if (mylist.Size > 0) {
        TraverseRight(mylist);

        //Traverse next if greater than one
        if (mylist.Size > 1) {
            TraverseRight(mylist);
            let element = document.getElementById("rightbtn");
            element.disabled = false;
        }
            
    }
}



/**
    Returns a pointer to the current node in the list in Right traversal
 */
function TraverseRight(list) {

    if (list.Current === null
        && list.Size > 0)//Start of traversal
    {
        list.Current = list.Head;
    }
    else if (list.Current !== null && list.Current.Next !== null)//Only when we can traverse the list
    {
        list.Current = list.Current.Next;
    }

}

/**
    Returns a pointer to the current list in Left traversal
 */
function TraverseLeft(list) {
    if (list.Current === null
        && list.Size > 0)//Start of traversal
    {
        list.Current = list.Head;
    }
    else if (list.Current !== null && list.Current !== list.Head && list.Size > 1)//Only when we can traverse the list
    {                                                   //Since it is not the head, and the list has previous
        list.Current = list.Current.Prev;
    }

}

//Left get prev value
//While right get current value
function PrevButton() {

    let leftname = document.getElementById("leftname");
    let leftgrade = document.getElementById("leftgrade");
    let rightname = document.getElementById("rightname");
    let rightgrade = document.getElementById("rightgrade");


    TraverseLeft(mylist);

    if (mylist.Current !== null) {

        if (mylist.Size > 1) {
            let current = mylist.Current.Prev;

            //Make updates if prev has values
            if (current !== null) {
                leftname.innerText = current.Data.FirstName + " " + current.Data.LastName;
                leftgrade.innerText = current.Data.Grade;

                //Right for current values
                rightname.innerText = mylist.Current.Data.FirstName + " " + mylist.Current.Data.LastName;
                rightgrade.innerText = mylist.Current.Data.Grade;

                //Disable previos button if prev will not have value
                if (current.Prev == null) {
                    document.getElementById("leftbtn").disabled = true;
                }
            }

            //Enable next if the next value exit
            if (mylist.Current.Next !== null)
                document.getElementById("rightbtn").disabled = false;
        }

    } else {
        //Something went wrong or the list is empty
        return false;
    }
}

function NextButton() {
    let leftname = document.getElementById("leftname");
    let leftgrade = document.getElementById("leftgrade");
    let rightname = document.getElementById("rightname");
    let rightgrade = document.getElementById("rightgrade");

    TraverseRight(mylist)

    //Update values
    if (mylist.Current !== null) {
        if (mylist.Size === 1) {
            leftname.innerText = mylist.Current.Data.FirstName + " " + mylist.Current.Data.LastName;
            leftgrade.innerText = mylist.Current.Data.Grade;

        } else {
            leftname.innerText = mylist.Current.Data.FirstName + " " + mylist.Current.Data.LastName;
            leftgrade.innerText = mylist.Current.Data.Grade;

            let node = mylist.Current.Next;

            if (node !== null) {
                rightname.innerText = node.Data.FirstName + " " + node.Data.LastName;
                rightgrade.innerText = node.Data.Grade;

                //Disable element if next element is null
                if (node.Next === null) {
                    document.getElementById("rightbtn").disabled = true;
                }

                
            }

            //enable previous button if prev exists
            if (mylist.Current.Prev !== null)
                document.getElementById("leftbtn").disabled = false;

        }
    } else {
        //Most likely an empty/corrupted list
        return false;
    }
}
